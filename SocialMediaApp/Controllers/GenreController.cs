using BusinessLayer.Concrete;
using BusinessLayer.Validations;
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

        [HttpGet]
        public IActionResult Add()
        {
            Genre genre = new Genre();
            return View(genre);
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            GenreValidator genreValidator = new GenreValidator();
            var result = genreValidator.Validate(genre);

            if (result.IsValid)
            {
                genreManager.GenreInsert(genre);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Add");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Genre genre = genreManager.GetGenreById(id);
            return View(genre);
        }        
        
        [HttpPost]
        public IActionResult Update(Genre genre)
        {
            GenreValidator genreValidator = new GenreValidator();
            var result = genreValidator.Validate(genre);

            if (result.IsValid)
            {
                genreManager.GenreUpdate(genre);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(genre);
            }
        }
    }
}
