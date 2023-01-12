using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace SocialMediaApp.Controllers
{
    public class GenreController : Controller
    {
        GenreManager genreManager = new GenreManager(new EfGenreRepository());

        public IActionResult Index()
        {
            return View(genreManager.GenreList());
        }
        
        public IActionResult Delete(int id)
        {
            var genre = genreManager.GetGenreById(id);
            genre.IsActive = false;
            genreManager.GenreUpdate(genre);

            return RedirectToAction("Index");
        }
    }
}
