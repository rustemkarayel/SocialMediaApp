using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using SocialMediaApp.Models;
using System.ComponentModel;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
    public class SavedCollectionController : Controller
    {
        SavedCollectionManager scm = new SavedCollectionManager(new EfSavedCollectionRepository());
        SavedManager sm = new SavedManager(new EfSavedRepository());
        CollectionManager cm = new CollectionManager(new EfCollectionRepository());

        public IActionResult Index(int page=1,int pageSize=5)
        {
            var savedCollections = scm.SavedCollectionList().ToPagedList(page, pageSize);
            return View(savedCollections);
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
