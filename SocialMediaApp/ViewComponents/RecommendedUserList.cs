using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.ViewComponents
{
	public class RecommendedUserList: ViewComponent
	{
		
		public async Task<IViewComponentResult> getRecommendedUserList()
		{
			return View();
		}
	}
}
