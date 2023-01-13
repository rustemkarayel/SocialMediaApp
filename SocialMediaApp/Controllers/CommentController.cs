using BusinessLayer.Concrete;
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

            return RedirectToAction("Index");
        }        
        
        public IActionResult Add()
        {
            CommentPostUserCommentList model = new CommentPostUserCommentList();
            model.CommentModel = new Comment();
            model.CommentListModel = commentManager.CommentList();
            model.UserModel = userManager.UserList();
            model.PostModel = postManager.PostList();

            return View(model);
        }
    }
}
