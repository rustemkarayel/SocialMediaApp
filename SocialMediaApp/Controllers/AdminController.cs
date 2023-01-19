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

namespace SocialMediaApp.Controllers
{

    public class AdminController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminRepository());
        private readonly IToastNotification _toastNotification;
        //logger ekle!
        public AdminController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
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
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Entry(Admin admin)
        {
            Context c = new Context();
            var result = c.Admins.Where(x => x.AdminMail == admin.AdminMail && x.AdminPassword == admin.AdminPassword).SingleOrDefault();
            if (result != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Email, admin.AdminMail) };

                var userIdentify = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);
                //  await HttpContext.SignInAsync(principal);
                await HttpContext
                    .SignInAsync(
                    principal,
                    new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(5) });
                return RedirectToAction("AdminList", "Admin");
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

        [HttpGet]
        public IActionResult Index(int page=1,int pageSize = 5)
        {
            var admins=adminManager.AdminList().ToPagedList(page, pageSize);
            return View(admins);  
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
        public IActionResult Update()
        {
            return View();
        }        
        
        [HttpPost]
        public IActionResult Update(Admin admin)
        {
            AdminValidator validator  = new AdminValidator();
            var result = validator.Validate(admin);

            if (result.IsValid)
            {
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
    }
}
