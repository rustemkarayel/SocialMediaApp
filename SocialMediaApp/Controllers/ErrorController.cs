using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
	[Route("error")]
	public class ErrorController : Controller
	{
		[Route("/Error/HandleError/{code:int}")]
		public IActionResult HandleError(int code)
		{
			ViewBag.code = code.ToString();
			switch (code)
			{
				case 404:
					ViewBag.msg = "Uh Oh! Page not found!";
					break;
				case 500:
					ViewBag.msg = "Uh Oh! Internal Error!";
					break;
			}
			return View();
		}
	}
}
