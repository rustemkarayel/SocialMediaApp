using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class TagController : Controller
    {
        TagManager tagManager = new TagManager(new EfTagRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        PostManager postManager = new PostManager(new EfPostRepository());
        public IActionResult Index()
        {
            var tags = tagManager.TagList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Add()
        {
            TagUserPostModel tagUserPostModel = new TagUserPostModel();

            tagUserPostModel.tagModel = new Tag();
            tagUserPostModel.userModel = userManager.UserList();
            tagUserPostModel.postModel = postManager.PostList();

            return View(tagUserPostModel);
        }        
        
        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            return RedirectToAction("Index");
        }
    }
}
