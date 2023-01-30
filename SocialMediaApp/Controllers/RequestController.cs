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
    public class RequestController : Controller
    {
        RequestManager rm = new RequestManager(new EfRequestRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var requests = rm.RequestList().ToPagedList();
            //return View(requests);
            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Request> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Requests.Where(request => request.Follower.NickName.Contains(searchText) || request.Follower.FirstName.Contains(searchText) ||
                request.Follower.LastName.Contains(searchText) ||request.Follower.Mail.Contains(searchText) ||
                request.Follower.Country.Contains(searchText) || request.Follower.Phone.Contains(searchText) ||
                request.Following.NickName.Contains(searchText) || request.Following.FirstName.Contains(searchText) || request.Following.LastName.Contains(searchText)
                || request.Following.Mail.Contains(searchText) || request.Following.Phone.Contains(searchText) || request.Following.Country.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Requests.Where(request => request.Follower.NickName.Contains(searchText) || request.Follower.FirstName.Contains(searchText) ||
                request.Follower.LastName.Contains(searchText) || request.Follower.Mail.Contains(searchText) ||
                request.Follower.Country.Contains(searchText) || request.Follower.Phone.Contains(searchText) ||
                request.Following.NickName.Contains(searchText) || request.Following.FirstName.Contains(searchText) || request.Following.LastName.Contains(searchText)
                || request.Following.Mail.Contains(searchText) || request.Following.Phone.Contains(searchText) || request.Following.Country.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Requests.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Requests.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Request";
            ViewBag.actionName = "RequestList";
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            RequestUserModel rum = new RequestUserModel();
            rum.RequestModel = new Request();
            rum.UserModel = um.UserList();

            return View(rum);
        }
        [HttpPost]
        public IActionResult Add(Request request)
        {
            RequestValidator requestValidator = new RequestValidator();
            var result = requestValidator.Validate(request);
            if (result.IsValid)
            {
                rm.RequestInsert(request);
                return RedirectToAction("RequestList");
            }
            else
            {
                RequestUserModel rum = new RequestUserModel();
                rum.RequestModel = request;
                rum.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(rum);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Request request = rm.GetRequestById(id);
            RequestUserModel rum = new RequestUserModel();
            rum.RequestModel = request;
            rum.UserModel = um.UserList();
            return View(rum);
        }
        [HttpPost]
        public IActionResult Update(Request request)
        {
            RequestValidator requestValidator = new RequestValidator();
            var result = requestValidator.Validate(request);
            if (result.IsValid)
            {
                rm.RequestUpdate(request);
                return RedirectToAction("RequestList");
            }
            else
            {
                RequestUserModel rum = new RequestUserModel();
                rum.RequestModel = request;
                rum.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(rum);
            }
        }
        public IActionResult Delete(int id)
        {
            Request request = rm.GetRequestById(id);
            request.IsActive = false;
            rm.RequestUpdate(request);
            return RedirectToAction("RequestList");
        }


    }
}
