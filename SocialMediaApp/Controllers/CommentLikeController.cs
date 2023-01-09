using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class CommentLikeController : Controller
    {
        CommentLikeManager clm = new CommentLikeManager(new EfCommentLikeRepository());
        public IActionResult Index()
        {
            var commentlikes = clm.CommentLikeList();
            return View(commentlikes);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CommentLike commentLike)
        {
            return View();
        }
    }
}
