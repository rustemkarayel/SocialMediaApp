﻿using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using System.Drawing.Printing;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
    public class CollectionController : Controller
    {
        CollectionManager collectionManager = new CollectionManager(new EfCollectionRepository());

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            return View(collectionManager.CollectionList().ToPagedList(page, pageSize));
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
