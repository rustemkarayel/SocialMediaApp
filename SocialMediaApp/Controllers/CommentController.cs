using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.PagedList;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        PostManager postManager = new PostManager(new EfPostRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            //return View(commentManager.CommentList().ToPagedList(page, pageSize));

            int pageSize = 5;

            Context c = new Context();
            Pager pager;
            List<Comment> data;

            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Comments.Where(
                        comment => comment.CommentContent.Contains(searchText) ||
                        comment.Commentor.FirstName.Contains(searchText) ||
                        comment.Post.PostContent.Contains(searchText) ||
                        comment.CommentContent.Contains(searchText) ||
                        comment.CommentTime.ToString().Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Comments.Where(
                        comment => comment.CommentContent.Contains(searchText) ||
                        comment.Commentor.FirstName.Contains(searchText) ||
                        comment.Post.PostContent.Contains(searchText) ||
                        comment.CommentContent.Contains(searchText) ||
                        comment.CommentTime.ToString().Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Comments.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Comments.ToList().Count;
            }

            pager = new Pager(pageSize, itemCounts, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "collection-list";
            ViewBag.contrName = "Collection";
            ViewBag.searchText = searchText;

            return View(data);
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
