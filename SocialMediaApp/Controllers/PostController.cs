using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMediaApp.Models;
using SocialMediaApp.PagedList;
namespace SocialMediaApp.Controllers
{

    public class PostController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public PostController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        PostManager pm = new PostManager(new EfPostRepository());
        GenreManager gm = new GenreManager(new EfGenreRepository());
        LocationManager lm = new LocationManager(new EfLocationRepository());
        UserManager um = new UserManager(new EfUserRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //var posts = pm.PostList().ToPagedList(page,pageSize);
            //return View(posts);

            int pageSize = 2;
            Context c = new Context();
            Pager pager;
            List<Post> data;
            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Posts.Where(post => post.Creator.NickName.Contains(searchText) || post.PostContent.Contains(searchText) ||
                post.Description.Contains(searchText)).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Posts.Where(post => post.Creator.NickName.Contains(searchText) || post.PostContent.Contains(searchText) ||
                post.Description.Contains(searchText)).ToList().Count;
            }
            else
            {
                data = c.Posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Posts.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);
            ViewBag.pager = pager;
            ViewBag.searchText = searchText;
            ViewBag.contrName = "Post";
            ViewBag.actionName = "PostList";
            return View(data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            PostGenreLocationUserModel pglum = new PostGenreLocationUserModel();
            pglum.PostModel = new Post();
            pglum.GenreModel = gm.GenreList();
            pglum.LocationModel = lm.LocationList();
            pglum.UserModel = um.UserList();
            return View(pglum);
        }
        [HttpPost]
        public IActionResult Add(Post post)
        {
            PostValidator postValidator = new PostValidator();
            var result = postValidator.Validate(post);
            if (result.IsValid)
            {
                var dizi = FileUpload(post);
                if (dizi != null && dizi.Length > 0)
                {
                    post.PostContent = dizi[0];
                    post.PostContent2 = dizi[1];
                    post.PostContent3 = dizi[2];
                }
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
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
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
                var dizi = FileUpload(post);
                if (dizi != null && dizi.Length > 0)
                {
                    post.PostContent = dizi[0];
                    post.PostContent2 = dizi[1];
                    post.PostContent3 = dizi[2];
                }
                pm.PostUpdate(post);
                return RedirectToAction("PostList");
            }
            else
            {
                PostGenreLocationUserModel pglum = new PostGenreLocationUserModel();
                pglum.PostModel = post;
                pglum.LocationModel = lm.LocationList();
                pglum.GenreModel = gm.GenreList();
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

        //Dosya yüklemek için metod oluşturuldu
        private string[] FileUpload(Post post)
        {
            string[] uniquefileName = new string[3];
            if (post.imgFiles != null && post.imgFiles.Count > 0)
            {
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "post_images");

                var i = 0;
                foreach (var file in post.imgFiles)
                {
                    uniquefileName[i] = Guid.NewGuid().ToString() + "_" + file.FileName;

                    string filePath = Path.Combine(uploadfolder, uniquefileName[i]);
                    i++;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            return uniquefileName;
        }
    }
}
