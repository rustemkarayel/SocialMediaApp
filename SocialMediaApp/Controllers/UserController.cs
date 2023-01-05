using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
