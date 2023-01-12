using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
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
        
        public IActionResult Delete(int id)
        {
            Collection collection = collectionManager.GetCollectionById(id);
            collection.IsActive = false;
            collectionManager.CollectionUpdate(collection);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            Collection collection = new Collection();
            return View(collection);
        }
    }
}
