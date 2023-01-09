using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class SavedController : Controller
    {
        SavedManager sm=new SavedManager(new EfSavedRepository());
        UserManager um=new UserManager(new EfUserRepository());
        PostManager pm=new PostManager(new EfPostRepository());
        public IActionResult Index()
        {
            var saveds=sm.SavedList();
            return View(saveds);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SavedUserPostModel supm=new SavedUserPostModel();
            supm.SavedModel = new Saved();
            supm.UserModel = um.UserList();
            supm.PostModel = pm.PostList();
            return View(supm);
        }
        [HttpPost]
        public IActionResult Add(Saved saved)
        {
            SavedValidator savedValidator = new SavedValidator();
            var result=savedValidator.Validate(saved);
            if(result.IsValid) 
            {
                sm.SavedInsert(saved);
                return RedirectToAction("Index");
            }
            else
            {
                SavedUserPostModel supm=new SavedUserPostModel();   
                supm.SavedModel = new Saved();
                supm.UserModel= um.UserList();
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
