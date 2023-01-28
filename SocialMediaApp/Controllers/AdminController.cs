using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NToastNotify;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using X.PagedList;
using BusinessLayer.Validations;
using Azure;
using Microsoft.AspNetCore.Identity;
using SocialMediaApp.Models;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using SocialMediaApp.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;

namespace SocialMediaApp.Controllers
{

    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment webHostEnvironment;

        //logger ekle!
        public AdminController(IToastNotification toastNotification, IWebHostEnvironment webHostEnvironment)
        {
            _toastNotification = toastNotification;
            this.webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Profile()
        {
			ClaimsPrincipal currentUser = this.User;
			var currentUserMail = currentUser.FindFirst(ClaimTypes.Email).Value;
            Admin admin = adminManager.AdminGetByEMail(currentUserMail);
			return View(admin);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Entry(Admin admin)
        {
            Context c = new Context();
            var result = c.Admins.Where(x => x.AdminMail == admin.AdminMail && x.AdminPassword == admin.AdminPassword).SingleOrDefault();
            if (result != null)
            {
                var isim = result.AdminFirstName + " " + result.AdminLastName;
                var claims = new List<Claim> { new Claim(ClaimTypes.Email, result.AdminMail), new Claim(ClaimTypes.Name,isim),
                new Claim(ClaimTypes.Actor,result.AdminType)};

                var userIdentify = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);
                //  await HttpContext.SignInAsync(principal);
                await HttpContext
                    .SignInAsync(
                    principal,
                    new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(30) });

                return RedirectToAction("AdminProfile", "Admin");
            }
            _toastNotification.AddErrorToastMessage("Username or password incorrect !");
            TempData["init"] = 1;
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        //sifreleme ekle!

        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var admins=adminManager.AdminList().ToPagedList(page, pageSize);
            //return View(admins);
           
            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Admin> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Admins.Where(admin => admin.AdminFirstName.Contains(searchText) || admin.AdminLastName.Contains(searchText) ||
                admin.AdminMail.Contains(searchText) || admin.AdminType.Contains(searchText) || 
                admin.imgUrl.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Admins.Where(admin => admin.AdminFirstName.Contains(searchText) || admin.AdminLastName.Contains(searchText) ||
                admin.AdminMail.Contains(searchText) || admin.AdminType.Contains(searchText) ||
                admin.imgUrl.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Admins.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Admins.ToList().Count;
            }

            pager = new Pager(itemCounts,pageSize,page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Admin";
            ViewBag.actionName = "AdminList";      
            return View(data);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            var result=adminValidator.Validate(admin);
            if (result.IsValid)
            {
                admin.imgUrl = FileUpload(admin);
                adminManager.AdminInsert(admin);
                return RedirectToAction("AdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Admin admin=adminManager.AdminGetById(id);
            admin.IsActive = false;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public IActionResult Update(string email)
		{
			ClaimsPrincipal currentUser = this.User;
			var currentUserMail = currentUser.FindFirst(ClaimTypes.Email).Value;

			Admin admin = adminManager.AdminGetByEMail(currentUserMail);
            return View(admin);
        }


        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            AdminValidator validator = new AdminValidator();
            var result = validator.Validate(admin);

            if (result.IsValid)
            {
                admin.imgUrl = FileUpload(admin);
                adminManager.AdminUpdate(admin);
                return RedirectToAction("AdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(admin);
            }
        }

        private string FileUpload(Admin user)
        {
            string uniquefileName = "";
            if (user.imgFile != null)
            {
                uniquefileName = Guid.NewGuid().ToString() + "_" + user.imgFile.FileName;
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "admin_images");
                string filePath = Path.Combine(uploadfolder, uniquefileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    user.imgFile.CopyTo(stream);
                }
            }
            return uniquefileName;
        }
    }
}
