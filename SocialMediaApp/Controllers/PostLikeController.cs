using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class PostLikeController : Controller
    {
        PostLikeManager plm = new PostLikeManager(new EfPostLikeRepository());
        public IActionResult Index()
        {
            var postlikes = plm.PostLikeList();
            return View(postlikes);
        }
    }
}
