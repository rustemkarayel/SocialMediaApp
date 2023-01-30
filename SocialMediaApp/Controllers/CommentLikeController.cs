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
    public class CommentLikeController : Controller
    {
        CommentLikeManager clm = new CommentLikeManager(new EfCommentLikeRepository());
        CommentManager cm = new CommentManager(new EfCommentRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var commentlikes = clm.CommentLikeList().ToPagedList(page,pageSize);
            //return View(commentlikes);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<CommentLike> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.CommentLikes.Where(commentLike => commentLike.CommentLiker.NickName.Contains(searchText) || commentLike.Comment.CommentContent.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.CommentLikes.Where(commentLike => commentLike.CommentLiker.NickName.Contains(searchText) || commentLike.Comment.CommentContent.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.CommentLikes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.CommentLikes.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "CommentLike";
            ViewBag.actionName = "CommentLikeList";
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            CommentLikeUserCommentModel cucm = new CommentLikeUserCommentModel();
            cucm.CommentLikeModel = new CommentLike();
            cucm.CommentModel = cm.CommentList();
            cucm.UserModel = um.UserList();
            return View(cucm);
        }
        [HttpPost]
        public IActionResult Add(CommentLike commentLike)
        {
            CommentLikeValidator commentLikeValidator = new CommentLikeValidator();
            var result = commentLikeValidator.Validate(commentLike);
            if (result.IsValid)
            {
                clm.CommentLikeInsert(commentLike);
                return RedirectToAction("CommentLikeList");
            }
            else
            {
                CommentLikeUserCommentModel cucm = new CommentLikeUserCommentModel();
                cucm.CommentLikeModel = commentLike;
                cucm.CommentModel = cm.CommentList();
                cucm.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(cucm);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CommentLike commentLike = clm.GetCommentLikeById(id);
            CommentLikeUserCommentModel cucm = new CommentLikeUserCommentModel();
            cucm.CommentLikeModel = commentLike;
            cucm.CommentModel = cm.CommentList();
            cucm.UserModel = um.UserList();
            return View(cucm);
        }
        [HttpPost]
        public IActionResult Update(CommentLike commentLike)
        {
            CommentLikeValidator commentLikeValidator = new CommentLikeValidator();
            var result = commentLikeValidator.Validate(commentLike);
            if (result.IsValid)
            {
                clm.CommmentLikeUpdate(commentLike);
                return RedirectToAction("CommentLikeList");
            }
            else
            {
                CommentLikeUserCommentModel cucm = new CommentLikeUserCommentModel();
                cucm.CommentLikeModel = commentLike;
                cucm.CommentModel = cm.CommentList();
                cucm.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(cucm);
            }
        }
        public IActionResult Delete(int id)
        {
            CommentLike commentLike = clm.GetCommentLikeById(id);
            commentLike.IsActive = false;
            clm.CommmentLikeUpdate(commentLike);
            return RedirectToAction("CommentLikeList");
        }
    }
}
