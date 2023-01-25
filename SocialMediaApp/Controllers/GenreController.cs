using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.PagedList;

namespace SocialMediaApp.Controllers
{
    public class GenreController : Controller
    {
        GenreManager genreManager = new GenreManager(new EfGenreRepository());

        public IActionResult Index(int page = 1, string searchText = "")
        {
            //return View(genreManager.GenreList().ToPagedList(page, pageSize));

            int pageSize = 5;

            Context c = new Context();
            Pager pager;
            List<Genre> data;

            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Genres.Where(
                        genre=>genre.GenreName.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Genres.Where(
						genre => genre.GenreName.Contains(searchText)
				).ToList().Count;
            }
            else
            {
                data = c.Genres.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Genres.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "genre-list";
            ViewBag.contrName = "Genre";
            ViewBag.searchText = searchText;

            return View(data);
        }
        
        public IActionResult Delete(int id)
        {
            var genre = genreManager.GetGenreById(id);
            genre.IsActive = false;
            genreManager.GenreUpdate(genre);

            return RedirectToAction("genre-list");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            GenreValidator genreValidator = new GenreValidator();
            var result = genreValidator.Validate(genre);

            if (result.IsValid)
            {
                genreManager.GenreInsert(genre);
                return RedirectToAction("genre-list");
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
                return RedirectToAction("genre-list");
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
