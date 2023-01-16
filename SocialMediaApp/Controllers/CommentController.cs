using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        PostManager postManager = new PostManager(new EfPostRepository());

        public IActionResult Index()
        {
            return View(commentManager.CommentList());
        }           
        
        public IActionResult Delete(int id)
        {
            Comment comment = commentManager.GetCommentById(id);
            comment.IsActive= false;
            commentManager.CommentUpdate(comment);

            return RedirectToAction("comment-list");
        }

        [HttpGet]
        public IActionResult Add()
        {
            CommentPostUserCommentList model = new CommentPostUserCommentList();
            model.CommentModel = new Comment();
            model.CommentListModel = commentManager.CommentList();
            model.UserModel = userManager.UserList();
            model.PostModel = postManager.PostList();

            return View(model);
        }        
        
        [HttpPost]
        public IActionResult Add(Comment comment)
        {
            CommentValidator commentValidator = new CommentValidator();
            var result = commentValidator.Validate(comment);

            if(result.IsValid)
            {
                commentManager.CommentInsert(comment);
                return RedirectToAction("comment-list");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                CommentPostUserCommentList model = new CommentPostUserCommentList();

                model.CommentModel = comment;
                model.CommentListModel = commentManager.CommentList();
                model.UserModel = userManager.UserList();
                model.PostModel = postManager.PostList();

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            CommentPostUserCommentList model = new CommentPostUserCommentList();

            model.CommentModel = commentManager.GetCommentById(id);
            model.CommentListModel = commentManager.CommentList();
            model.UserModel = userManager.UserList();
            model.PostModel = postManager.PostList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Comment comment)
        {
            CommentValidator commentValidator = new CommentValidator();
            var result = commentValidator.Validate(comment);

            if (result.IsValid)
            {
                commentManager.CommentUpdate(comment);
                return RedirectToAction("comment-list");
            }
            else
            {
                CommentPostUserCommentList model = new CommentPostUserCommentList();

                model.CommentModel = comment;
                model.CommentListModel = commentManager.CommentList();
                model.UserModel = userManager.UserList();
                model.PostModel = postManager.PostList();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(model);
            }
        }
    } 
}
