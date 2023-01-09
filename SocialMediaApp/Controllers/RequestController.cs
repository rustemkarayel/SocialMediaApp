using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class RequestController : Controller
    {
        RequestManager rm = new RequestManager(new EfRequestRepository());
        public IActionResult Index()
        {
            var requests = rm.RequestList();
            return View(requests);
        }
    }
}
