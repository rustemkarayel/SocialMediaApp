using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
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
        GenreManager gm= new GenreManager(new EfGenreRepository());
        LocationManager lm=new LocationManager(new EfLocationRepository());
        UserManager um=new UserManager(new EfUserRepository());   
        public IActionResult Index(int page=1,string searchText="")
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
            post.PostContent = FileUpload(post);
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
            post.PostContent = FileUpload(post);
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

        //Dosya yüklemek için metod oluşturuldu

        private string FileUpload(Post post)
        {
            string uniquefileName = "";
            if (post.imgFile != null)
            {
                uniquefileName = Guid.NewGuid().ToString() + "_" + post.imgFile.FileName;
                string uploadfolder = Path.Combine(webHostEnvironment.WebRootPath, "post_images");
                string filePath = Path.Combine(uploadfolder, uniquefileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    post.imgFile.CopyTo(stream);
                }
            }
            return uniquefileName;
        }

    }
}
