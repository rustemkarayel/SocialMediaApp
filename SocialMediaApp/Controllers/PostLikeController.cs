using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class PostLikeController : Controller
    {
        PostLikeManager plm = new PostLikeManager(new EfPostLikeRepository());
        PostManager pm = new PostManager(new EfPostRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var postlikes = plm.PostLikeList();
            return View(postlikes);
        }
        [HttpGet]
        public IActionResult Add()
        {
            PostLikeUserPostModel pupm = new PostLikeUserPostModel();
            pupm.PostLikeModel = new PostLike();
            pupm.PostModel = pm.PostList();
            pupm.UserModel = um.UserList();
            return View(pupm);
        }
        [HttpPost]
        public IActionResult Add(PostLike postLike)
        {
            PostLikeValidator postLikeValidator = new PostLikeValidator();
            var result = postLikeValidator.Validate(postLike);
            if (result.IsValid)
            {
                plm.PostLikeInsert(postLike);
                return RedirectToAction("Index");
            }
            else
            {
                PostLikeUserPostModel pupm = new PostLikeUserPostModel();
                pupm.PostLikeModel = postLike;
                pupm.UserModel = um.UserList();
                pupm.PostModel = pm.PostList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(pupm);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            PostLike postLike = plm.GetPostLikeById(id);
            PostLikeUserPostModel pupm = new PostLikeUserPostModel();
            pupm.PostLikeModel = postLike;
            pupm.UserModel = um.UserList();
            pupm.PostModel = pm.PostList();
            return View(pupm);
        }
        [HttpPost]
        public IActionResult Update(PostLike postLike)
        {
            PostLikeValidator postLikeValidator= new PostLikeValidator();
            var result=postLikeValidator.Validate(postLike);
            if (result.IsValid)
            {
                plm.PostLikeUpdate(postLike);
                return RedirectToAction("Index");
            }
            else
            {
                PostLikeUserPostModel pupm = new PostLikeUserPostModel();
                pupm.PostLikeModel = postLike;
                pupm.UserModel = um.UserList();
                pupm.PostModel= pm.PostList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(pupm);
            }
        }
        public IActionResult Delete(int id)
        {
            PostLike postLike = plm.GetPostLikeById(id);
            postLike.IsActive = false;
            plm.PostLikeUpdate(postLike);
            return RedirectToAction("Index");
        }
    }
}
