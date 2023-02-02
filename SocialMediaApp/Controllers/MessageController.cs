using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.PagedList;

namespace SocialMediaApp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        UserManager um=new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var messages = mm.MessageList().ToPagedList(page,pageSize);
            //return View(messages);

            TempData["page"] = page;
            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Message> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Messages.Where(message => message.Sender.NickName.Contains(searchText) || message.Receiver.NickName.Contains(searchText) ||
                message.MessageContent.Contains(searchText) || message.SendDate.ToString().Contains(searchText) || message.SendTime.ToString().Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Messages.Where(message => message.Sender.NickName.Contains(searchText) || message.Receiver.NickName.Contains(searchText) ||
                message.MessageContent.Contains(searchText) || message.SendDate.ToString().Contains(searchText) || message.SendTime.ToString().Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Messages.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Messages.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Message";
            ViewBag.actionName = "MessageList";
            return View(data);
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
                mum.MessageModel = message;
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
            int page = (int)TempData["page"];
            return RedirectToAction("MessageList", new { page, searchText = "" });
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
                int page = (int)TempData["page"];
                return RedirectToAction("MessageList", new { page, searchText = "" });
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
