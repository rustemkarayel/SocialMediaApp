using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EfPostRepository());
        public IActionResult Index()
        {
            var posts = pm.PostList();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            PostValidator postValidator = new PostValidator();
            var result=postValidator.Validate(post);
            if (result.IsValid)
            {
                pm.PostInsert(post);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
