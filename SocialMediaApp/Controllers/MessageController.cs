using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        UserManager um=new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1,int pageSize=5)
        {
            var messages = mm.MessageList().ToPagedList(page,pageSize);
            return View(messages);
        }

        [HttpGet]
        public IActionResult Add()
        {
            MessageUserModel  mum=new MessageUserModel();
            mum.MessageModel = new Message();
            mum.UserModel = um.UserList();
            return View(mum);
        }
        [HttpPost]
        public IActionResult Add(Message message) 
        {
            MessageValidator messageValidator= new MessageValidator();
            var result=messageValidator.Validate(message);
            if(result.IsValid)
            {
                mm.MessageInsert(message);
                return RedirectToAction("MessageList");
            }
            else
            {
                MessageUserModel mum=new MessageUserModel();
                mum.MessageModel = new Message();
                mum.UserModel = um.UserList();              
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(mum);
            }
        }

        public IActionResult Delete(int id)
        {
            Message message=mm.MessageGetById(id);
            message.IsActive= false;
            mm.MessageUpdate(message);  
            return RedirectToAction("MessageList");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Message message= mm.MessageGetById(id);
            MessageUserModel mum=new MessageUserModel();
            mum.MessageModel = message;
            mum.UserModel= um.UserList();
            return View(mum);
           
        }
        [HttpPost]
        public IActionResult Update(Message message)
        {
            MessageValidator messageValidator = new MessageValidator();
            var result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                mm.MessageUpdate(message);
                return RedirectToAction("MessageList");
            }
            else
            {
                MessageUserModel mum = new MessageUserModel();
                mum.MessageModel = message;
                mum.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(mum);
            }
        }        
    }
}
