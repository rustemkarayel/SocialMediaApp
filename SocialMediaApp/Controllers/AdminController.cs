using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using NToastNotify;

namespace SocialMediaApp.Controllers
{

    public class AdminController : Controller
    {
        private readonly IToastNotification _toastNotification;

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
                    new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(1) });
                return RedirectToAction("UserList", "User");
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

    }
}
