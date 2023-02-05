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
            var dizi = FileUpload(post);
            if (dizi != null && dizi.Length > 0)
            {
                post.PostContent = dizi[0];
                post.PostContent2 = dizi[1];
                post.PostContent3 = dizi[2];
            }
            return RedirectToAction("Anasayfa");
        }
		[HttpGet]
		public IActionResult Comment(Post post)
		{
			return View(post);
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

        //Post date calculate
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

        //Dosya yüklemek için metod oluşturuldu
        private string[] FileUpload(Post post)
        {
            var count = 0;
            string[] uniquefileNames = new string[3];

            List<IFormFile> fileList = new List<IFormFile>();
            if (post.imgFile1 != null)
            {
                fileList.Add(post.imgFile1);
                count++;
            }
            else
            {
                fileList.Add(post.imgFile1);
            }


            if (post.imgFile2 != null)
            {
                fileList.Add(post.imgFile2);
                count++;
            }
            else
            {
                fileList.Add(post.imgFile2);
            }
            if (post.imgFile3 != null)
            {
                fileList.Add(post.imgFile3);
                count++;
            }
            else
            {
                fileList.Add(post.imgFile3);
            }

            if (count > 0)
            {


                switch (count)
                {
                    case 1:
                        uniquefileNames = checkImageUpdated(fileList, post);
                        break;
                    case 2:
                        uniquefileNames = checkImageUpdated(fileList, post);
                        break;
                    case 3:
                        uniquefileNames = checkImageUpdated(fileList, post);
                        break;
                }
            }
            else
            {

                uniquefileNames[0] = post.PostContent;
                uniquefileNames[1] = post.PostContent2;
                uniquefileNames[2] = post.PostContent3;
            }

            return uniquefileNames;


        }
        private string[] checkImageUpdated(List<IFormFile> fileList, Post post)
        {
            string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "post_images");
            string filePath;
            string[] uniquefileNames = new string[3];
            for (var i = 0; i < fileList.Count; i++)
            {
                if (fileList[i] != null)
                {
                    uniquefileNames[i] = Guid.NewGuid().ToString() + "_" + fileList[i].FileName;
                    filePath = Path.Combine(uploadfolder, uniquefileNames[i]);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        fileList[i].CopyTo(stream);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        uniquefileNames[i] = post.PostContent;
                    }
                    else if (i == 1)
                    {
                        uniquefileNames[i] = post.PostContent2;
                    }
                    else
                    {
                        uniquefileNames[i] = post.PostContent3;
                    }

                }
            }
            return uniquefileNames;
        }
    }
}