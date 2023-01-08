using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        UserManager um=new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var messages = mm.MessageList();
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
                return RedirectToAction("Index");
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

    }
}
