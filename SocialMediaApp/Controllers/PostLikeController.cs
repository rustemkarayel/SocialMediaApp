using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.PagedList;

namespace SocialMediaApp.Controllers
{
    public class PostLikeController : Controller
    {
        PostLikeManager plm = new PostLikeManager(new EfPostLikeRepository());
        PostManager pm = new PostManager(new EfPostRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page=1,string searchText="")
        {
            //var postlikes = plm.PostLikeList().ToPagedList(page,pageSize);
            //return View(postlikes);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<PostLike> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.PostLikes.Where(postLike => postLike.PostLiker.NickName.Contains(searchText) || postLike.Post.PostContent.Contains(searchText)
              ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.PostLikes.Where(postLike => postLike.PostLiker.NickName.Contains(searchText) || postLike.Post.PostContent.Contains(searchText)
              ).ToList().Count;
            }
            else
            {
                data = c.PostLikes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.PostLikes.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "PostLike";
            ViewBag.actionName = "PostLikeList";
            return View(data);
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
                return RedirectToAction("PostLikeList");
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
                return RedirectToAction("PostLikeList");
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
            return RedirectToAction("PostLikeList");
        }
    }
}
