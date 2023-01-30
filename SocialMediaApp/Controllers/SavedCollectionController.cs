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
    public class SavedCollectionController : Controller
    {
        SavedCollectionManager scm = new SavedCollectionManager(new EfSavedCollectionRepository());
        SavedManager sm = new SavedManager(new EfSavedRepository());
        CollectionManager cm = new CollectionManager(new EfCollectionRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var savedCollections = scm.SavedCollectionList().ToPagedList(page, pageSize);
            //return View(savedCollections);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<SavedCollection> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.SavedCollections.Where(savedCollection => savedCollection.Saved.User.NickName.Contains(searchText) ||
                savedCollection.Saved.Post.PostContent.Contains(searchText) ||
                savedCollection.Collection.CollectionName.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.SavedCollections.Where(savedCollection => savedCollection.Saved.User.NickName.Contains(searchText) ||
                savedCollection.Saved.Post.PostContent.Contains(searchText) ||
                savedCollection.Collection.CollectionName.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.SavedCollections.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.SavedCollections.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "SavedCollection";
            ViewBag.actionName = "SavedCollectionList";
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            SavedCollectionSavedCollectionModel scscm = new SavedCollectionSavedCollectionModel();
            scscm.SavedCollectionModel = new SavedCollection();
            scscm.SavedModel = sm.SavedList();
            scscm.CollectionModel = cm.CollectionList();
            return View(scscm);
        }
        [HttpPost]
        public IActionResult Add(SavedCollection savedCollection)
        {
            SavedCollectionValidator savedCollectionValidator = new SavedCollectionValidator();
            var result = savedCollectionValidator.Validate(savedCollection);
            if (result.IsValid)
            {
                scm.SavedCollectionInsert(savedCollection);
                return RedirectToAction("SavedCollectionList");
            }
            else
            {
                SavedCollectionSavedCollectionModel scscm = new SavedCollectionSavedCollectionModel();
                scscm.SavedCollectionModel = savedCollection;
                scscm.SavedModel = sm.SavedList();
                scscm.CollectionModel = cm.CollectionList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(scscm);
            }
        }

        public IActionResult Delete(int id)
        {
            SavedCollection savedCollection = scm.SavedCollectionGetById(id);
            savedCollection.IsActive = false;
            scm.SavedCollectionUpdate(savedCollection);
            return RedirectToAction("SavedCollectionList");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SavedCollection savedCollection = scm.SavedCollectionGetById(id);
            SavedCollectionSavedCollectionModel scscm = new SavedCollectionSavedCollectionModel();
            scscm.SavedCollectionModel = savedCollection;
            scscm.SavedModel = sm.SavedList();
            scscm.CollectionModel = cm.CollectionList();
            return View(scscm);
        }
        [HttpPost]
        public IActionResult Update(SavedCollection savedCollection)
        {
            SavedCollectionValidator savedCollectionValidator = new SavedCollectionValidator();
            var result = savedCollectionValidator.Validate(savedCollection);
            if (result.IsValid)
            {
                scm.SavedCollectionUpdate(savedCollection);
                return RedirectToAction("SavedCollectionList");
            }
            else
            {
                SavedCollectionSavedCollectionModel scscm = new SavedCollectionSavedCollectionModel();
                scscm.SavedCollectionModel = savedCollection;
                scscm.SavedModel = sm.SavedList();
                scscm.CollectionModel = cm.CollectionList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(scscm);
            }
        }


    }
}
