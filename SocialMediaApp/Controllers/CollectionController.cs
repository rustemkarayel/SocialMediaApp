using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class CollectionController : Controller
    {
        CollectionManager collectionManager = new CollectionManager(new EfCollectionRepository());

        public IActionResult Index()
        {
            return View(collectionManager.CollectionList());
        }
    }
}
