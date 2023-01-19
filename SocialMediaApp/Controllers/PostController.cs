using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using X.PagedList;

namespace SocialMediaApp.Controllers
{
  
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EfPostRepository());
        GenreManager gm= new GenreManager(new EfGenreRepository());
        LocationManager lm=new LocationManager(new EfLocationRepository());
        UserManager um=new UserManager(new EfUserRepository());   
        public IActionResult Index(int page=1,int pageSize=5)
        {
            var posts = pm.PostList().ToPagedList(page,pageSize);
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            PostGenreLocationUserModel pglum= new PostGenreLocationUserModel();
            pglum.PostModel = new Post();
            pglum.GenreModel = gm.GenreList();
            pglum.LocationModel=lm.LocationList();
            pglum.UserModel = um.UserList();
            return View(pglum);
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            PostValidator postValidator = new PostValidator();
            var result=postValidator.Validate(post);
            if (result.IsValid)
            {
                pm.PostInsert(post);
                return RedirectToAction("PostList");
            }
            else
            {
                PostGenreLocationUserModel pglum = new PostGenreLocationUserModel();
                pglum.PostModel = post;
                pglum.GenreModel = gm.GenreList();
                pglum.LocationModel = lm.LocationList();
                pglum.UserModel = um.UserList();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View(pglum);
            }
            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Post post = pm.GetPostById(id);
            PostGenreLocationUserModel pglum = new PostGenreLocationUserModel();
            pglum.PostModel = post;
            pglum.GenreModel = gm.GenreList();
            pglum.LocationModel = lm.LocationList();
            pglum.UserModel = um.UserList();
            return View(pglum);

        }
        [HttpPost]
        public IActionResult Update(Post post)
        {
            PostValidator postValidator = new PostValidator();
            var result = postValidator.Validate(post);
            if (result.IsValid)
            {
                pm.PostUpdate(post);
                return RedirectToAction("PostList");
            }
            else
            {
                PostGenreLocationUserModel pglum = new PostGenreLocationUserModel();
                pglum.PostModel = post;
                pglum.LocationModel = lm.LocationList();
                pglum.GenreModel=gm.GenreList();
                pglum.UserModel = um.UserList();
                
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(pglum);
            }
        }
        public IActionResult Delete(int id)
        {
            Post post = pm.GetPostById(id);
            post.IsActive = false;
            pm.PostUpdate(post);
            return RedirectToAction("PostList");
        }

    }
}
