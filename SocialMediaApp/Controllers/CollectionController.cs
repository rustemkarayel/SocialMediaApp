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
    public class CollectionController : Controller
    {
        CollectionManager collectionManager = new CollectionManager(new EfCollectionRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            int pageSize = 2;

            Context context = new Context();
            Pager pager;
            List<Collection> data;

            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = context.Collections.Where(
                        collection=>collection.CollectionName.Contains(searchText) || 
                        collection.CreationDate.ToString().Contains(searchText) ||
                        collection.CreationTime.ToString().Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = context.Collections.Where(
                        collection => collection.CollectionName.Contains(searchText) ||
                        collection.CreationDate.ToString().Contains(searchText) ||
                        collection.CreationTime.ToString().Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = context.Collections.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = context.Collections.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "collection-list";
            ViewBag.contrName = "Collection";
            ViewBag.searchText = searchText;

            return View(data);

        }        
        
        public IActionResult Delete(int id)
        {
            Collection collection = collectionManager.GetCollectionById(id);
            collection.IsActive = false;
            collectionManager.CollectionUpdate(collection);

            return RedirectToAction("collection-list");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }        
        
        [HttpPost]
        public IActionResult Add(Collection collection)
        {
            CollectionValidator collectionValidator = new CollectionValidator();
            var result = collectionValidator.Validate(collection);

            if (result.IsValid)
            {
                collectionManager.CollectionInsert(collection);
                return RedirectToAction("collection-list");
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

        [HttpGet]
        public IActionResult Update(int id)
        {
            CollectionCollectionListModel collectionCollectionListModel = new CollectionCollectionListModel();

            collectionCollectionListModel.CollectionModel = collectionManager.GetCollectionById(id);
            collectionCollectionListModel.CollectionListModel = collectionManager.CollectionList();

            return View(collectionCollectionListModel);
        }

        [HttpPost]
        public IActionResult Update(Collection collection)
        {
            CollectionValidator collectionValidator = new CollectionValidator();
            var result = collectionValidator.Validate(collection);

            if (result.IsValid)
            {
                collectionManager.CollectionUpdate(collection);
                return RedirectToAction("collection-list");
            }
            else
            {
                CollectionCollectionListModel collectionCollectionListModel = new CollectionCollectionListModel();

                collectionCollectionListModel.CollectionModel = collection;
                collectionCollectionListModel.CollectionListModel = collectionManager.CollectionList();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(collectionCollectionListModel);
            }
        }
    }
}
