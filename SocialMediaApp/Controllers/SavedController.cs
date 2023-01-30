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
    public class SavedController : Controller
    {
        SavedManager sm = new SavedManager(new EfSavedRepository());
        UserManager um = new UserManager(new EfUserRepository());
        PostManager pm = new PostManager(new EfPostRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var saveds=sm.SavedList().ToPagedList(page,pageSize);
            //return View(saveds);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Saved> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Saveds.Where(saved => saved.User.NickName.Contains(searchText) || saved.Post.PostContent.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Saveds.Where(saved => saved.User.NickName.Contains(searchText) || saved.Post.PostContent.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Saveds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Saveds.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Saved";
            ViewBag.actionName = "SavedList";
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SavedUserPostModel supm = new SavedUserPostModel();
            supm.SavedModel = new Saved();
            supm.UserModel = um.UserList();
            supm.PostModel = pm.PostList();
            return View(supm);
        }
        [HttpPost]
        public IActionResult Add(Saved saved)
        {
            SavedValidator savedValidator = new SavedValidator();
            var result = savedValidator.Validate(saved);
            if (result.IsValid)
            {
                sm.SavedInsert(saved);
                return RedirectToAction("SavedList");
            }
            else
            {
                SavedUserPostModel supm = new SavedUserPostModel();
                supm.SavedModel = saved;
                supm.UserModel = um.UserList();
                supm.PostModel = pm.PostList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(supm);
            }
        }

        public IActionResult Delete(int id)
        {
            Saved saved = sm.SavedGetById(id);
            saved.IsActive = false;
            sm.SavedUpdate(saved);
            return RedirectToAction("SavedList");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Saved saved = sm.SavedGetById(id);
            SavedUserPostModel supm = new SavedUserPostModel();
            supm.SavedModel = saved;
            supm.UserModel = um.UserList();
            supm.PostModel = pm.PostList();
            return View(supm);
        }
        [HttpPost]
        public IActionResult Update(Saved saved)
        {
            SavedValidator savedValidator = new SavedValidator();
            var result = savedValidator.Validate(saved);
            if (result.IsValid)
            {
                sm.SavedUpdate(saved);
                return RedirectToAction("SavedList");
            }
            else
            {
                SavedUserPostModel supm = new SavedUserPostModel();
                supm.SavedModel = saved;
                supm.UserModel = um.UserList();
                supm.PostModel = pm.PostList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(supm);
            }
        }
    }
}
