using System.Diagnostics;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class HomeController : Controller
    {
        PostManager postManager = new PostManager(new EfPostRepository());
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController( ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Index()
        {           
            return View(postManager.PostList());
        }

        [HttpGet]
        public IActionResult Message()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            return View();
        }
        public IActionResult Notification()
        {
            return View();
        }
		[HttpGet]
		public IActionResult PostCreate()
		{		
			return View();
		}
		[HttpPost]
		public IActionResult PostCreate(Post post)
		{			
			postManager.PostInsert(post);
			return RedirectToAction("Anasayfa");

       }
		[HttpGet]
		public IActionResult Comment(int postId)
		{
			return View(postManager.GetPostById(postId));
		}
		[HttpPost]
		public IActionResult Comment(Comment comment)
		{
			return View();
		}
		[HttpGet]
		public IActionResult Story()
		{
			return View();

		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

		static string GetPrettyDate(DateTime d)
		{
			// 1.
			// Get time span elapsed since the date.
			TimeSpan s = DateTime.Now.Subtract(d);

			// 2.
			// Get total number of days elapsed.
			int dayDiff = (int)s.TotalDays;

			// 3.
			// Get total number of seconds elapsed.
			int secDiff = (int)s.TotalSeconds;

			// 4.
			// Don't allow out of range values.
			if (dayDiff < 0 || dayDiff >= 31)
			{
				return null;
			}

			// 5.
			// Handle same-day times.
			if (dayDiff == 0)
			{
				// A.
				// Less than one minute ago.
				if (secDiff < 60)
				{
					return "just now";
				}
				// B.
				// Less than 2 minutes ago.
				if (secDiff < 120)
				{
					return "1 minute ago";
				}
				// C.
				// Less than one hour ago.
				if (secDiff < 3600)
				{
					return string.Format("{0} minutes ago",
						Math.Floor((double)secDiff / 60));
				}
				// D.
				// Less than 2 hours ago.
				if (secDiff < 7200)
				{
					return "1 hour ago";
				}
				// E.
				// Less than one day ago.
				if (secDiff < 86400)
				{
					return string.Format("{0} hours ago",
						Math.Floor((double)secDiff / 3600));
				}
			}
			// 6.
			// Handle previous days.
			if (dayDiff == 1)
			{
				return "yesterday";
			}
			if (dayDiff < 7)
			{
				return string.Format("{0} days ago",
				dayDiff);
			}
			if (dayDiff < 31)
			{
				return string.Format("{0} weeks ago",
				Math.Ceiling((double)dayDiff / 7));
			}
			return null;
		}


    }
}