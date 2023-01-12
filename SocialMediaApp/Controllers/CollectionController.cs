using BusinessLayer.Concrete;
using BusinessLayer.Validations;
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
        
        [HttpPost]
        public IActionResult Add(Collection collection)
        {
            CollectionValidator collectionValidator = new CollectionValidator();
            var result = collectionValidator.Validate(collection);

            if (result.IsValid)
            {
                collectionManager.CollectionInsert(collection);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(collection);
            }
        }
    }
}
