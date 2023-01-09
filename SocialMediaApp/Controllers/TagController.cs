using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class TagController : Controller
    {
        TagManager tagManager = new TagManager(new EfTagRepository());
        public IActionResult Index()
        {
            var tags = tagManager.TagList();
            return View(tags);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }        
        
        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            return RedirectToAction("Index");
        }
    }
}
