using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class RequestController : Controller
    {
        RequestManager rm = new RequestManager(new EfRequestRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            var requests = rm.RequestList();
            return View(requests);
        }
        [HttpGet]
        public IActionResult Add()
        {
            RequestUserModel requestModel = new RequestUserModel();
            requestModel.RequestModel = new Request();
            requestModel.UserModel = um.UserList();

            return View(requestModel);
        }
        [HttpPost]
        public IActionResult Add(Request request)
        {

            return RedirectToAction("Index");
        }

    }
}
