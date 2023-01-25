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
    public class TagController : Controller
    {
        TagManager tagManager = new TagManager(new EfTagRepository());
        UserManager userManager = new UserManager(new EfUserRepository());
        PostManager postManager = new PostManager(new EfPostRepository());
        
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //return View(tagManager.TagList().ToPagedList(page, pageSize));
            int pageSize = 5;

            Context c = new Context();
            Pager pager;
            List<Tag> data;

            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Tags.Where(
                    tag=>tag.TaggedUser.NickName.Contains(searchText) ||
                    tag.Post.PostContent.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Tags.Where(
                        tag => tag.TaggedUser.FirstName.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Tags.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Tags.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "tag-list";
            ViewBag.contrName = "Tag";
            ViewBag.searchText = searchText;

            return View(data);
        }
        
        public IActionResult Delete(int id)
        {
            Tag tag = tagManager.GetTagById(id);
            tag.IsActive = false;
            tagManager.TagUpdate(tag);
            return RedirectToAction("tag-list");
        }

        [HttpGet]
        public IActionResult Add()
        {
            TagUserPostModel tagUserPostModel = new TagUserPostModel();

            tagUserPostModel.tagModel = new Tag();
            tagUserPostModel.userModel = userManager.UserList();
            tagUserPostModel.postModel = postManager.PostList();

            return View(tagUserPostModel);
        }        
        
        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            TagValidator tagValidator = new TagValidator();
            var result = tagValidator.Validate(tag);

            if (result.IsValid)
            {
                tagManager.TagInsert(tag);
                return RedirectToAction("tag-list");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                TagUserPostModel tagUserPostModel = new TagUserPostModel();

                tagUserPostModel.tagModel = tag;
                tagUserPostModel.userModel = userManager.UserList();
                tagUserPostModel.postModel = postManager.PostList();

                return View(tagUserPostModel);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            TagUserPostModel tagUserPostModel = new TagUserPostModel();

            tagUserPostModel.tagModel = tagManager.GetTagById(id);
            tagUserPostModel.userModel = userManager.UserList();
            tagUserPostModel.postModel = postManager.PostList();

            return View(tagUserPostModel);
        }

        [HttpPost]
        public IActionResult Update(Tag tag)
        {
           TagValidator tagValidator = new TagValidator();
           var result = tagValidator.Validate(tag);

           if(result.IsValid)
           {
                tagManager.TagUpdate(tag);
                return RedirectToAction("tag-list");
           }
            else
            {

                TagUserPostModel tagUserPostModel = new TagUserPostModel();

                tagUserPostModel.tagModel = tag;
                tagUserPostModel.userModel = userManager.UserList();
                tagUserPostModel.postModel = postManager.PostList();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(tagUserPostModel);
            }
        }

    }
}
