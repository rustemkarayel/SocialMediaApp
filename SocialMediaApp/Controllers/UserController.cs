using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.PagedList;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var users = um.UserList().ToPagedList(page,pageSize);
            //return View(users);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<User> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Users.Where(user => user.FirstName.Contains(searchText) || user.LastName.Contains(searchText) ||
                user.NickName.Contains(searchText) || user.Mail.Contains(searchText) || user.Birthday.ToString().Contains(searchText) || 
                user.PhotoUrl.Contains(searchText) || user.Phone.Contains(searchText) || user.Country.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Users.Where(user => user.FirstName.Contains(searchText) || user.LastName.Contains(searchText) ||
                user.NickName.Contains(searchText) || user.Mail.Contains(searchText) || user.Birthday.ToString().Contains(searchText) ||
                user.PhotoUrl.Contains(searchText) || user.Phone.Contains(searchText) || user.Country.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Users.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "User";
            ViewBag.actionName = "UserList";
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            UserValidator userValidator=new UserValidator();
            var result=userValidator.Validate(user);
            if(result.IsValid)
            {
                um.UserInsert(user);
                return RedirectToAction("UserList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            User user = um.UserGetById(id);
            user.IsActive = false;
            um.UserUpdate(user);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            User user = um.UserGetById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            UserValidator userValidator = new UserValidator();
            var result = userValidator.Validate(user);
            if (result.IsValid)
            {
                um.UserUpdate(user);
                return RedirectToAction("UserList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(user);
            }

        }
    }
}
