using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XtraBlogDb.Models;
using PagedList;
using PagedList.Mvc;

namespace XtraBlogDb.Controllers
{
    public class HomeController : Controller
    {
        BlogManager blogManager = new BlogManager(new EfBlogDAL(), new TagManager(new EfTagDAL()));
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDAL());
        TagManager TagManager = new TagManager(new EfTagDAL());
        UserManager userManager = new UserManager(new EfUserDAL(), new TitleManager(new EfTitleDAL()));
        TitleManager titleManager = new TitleManager(new EfTitleDAL());
        CommentManager CommentManager = new CommentManager(new EfCommentDAL());
        AboutManager aboutManager = new AboutManager(new EfAboutDAL());
        // GET: Home
        public ActionResult Index(string searchText, int p = 1, int cateId = 0)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                return View(blogManager.GetblogDetailList().Where(x => x.Headline.Contains(searchText)).ToList().ToPagedList(p, 8));
            }
            else if (cateId != 0)
            {
                return View(blogManager.GetblogDetailList().Where(x => x.CategoryName == categoryManager.GetCategoryByCategoryId(cateId).Name).ToList().ToPagedList(p, 8));
            }
            return View(blogManager.GetblogDetailList().ToPagedList(p, 8));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogManager.GetBlogByBlogId(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            var category = categoryManager.GetCategoryByCategoryId(blog.CategoryId);
            ViewBag.CategoryName = category.Name;
            List<string> tags = new List<string>();
            foreach (var item in blogManager.GetBlogToTagByBlogIdList(blog.BlogId))
            {

                var tag = TagManager.GetTagByTagId(item.TagId);
                tags.Add(tag.Name + ",");
            }
            string a = tags.LastOrDefault();
            tags.RemoveAt(tags.IndexOf(a));
            var tagId = TagManager.GetTagByTagId(blogManager.GetBlogToTagByBlogIdList(blog.BlogId).LastOrDefault().TagId);
            tags.Add(tagId.Name);
            string tagString = "";
            foreach (var item in tags.ToList())
            {
                tagString = tagString + item;
            }
            ViewBag.TagList = tagString;
            int userByTitleId = userManager.GetUserByUserId(blog.UserId).TitleId;
            ViewBag.TitleName = titleManager.GetTitleByTitleId(userByTitleId).Name;
            string categoryName = categoryManager.GetCategoryByCategoryId(blog.CategoryId).Name;
            ViewBag.CategoryName = categoryName;
            BlogDetailViewModel blogDetailViewModel = new BlogDetailViewModel();
            blogDetailViewModel.Blog = blog;
            blogDetailViewModel.Blogs = blogManager.GetBlogList();
            blogDetailViewModel.Categories = categoryManager.GetCategoryList();
            blogDetailViewModel.Comments = CommentManager.GetCommentList();
            return View(blogDetailViewModel);
        }
        [HttpGet]
        public PartialViewResult CommentCreate(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult CommentCreate(Comment comment)
        {
            comment.Date = DateTime.Now.Date;
            comment.Visiblity = false;
            CommentManager.Add(comment);
            return PartialView();
            //your code 
            Response.Redirect("~/Home/Details/" + comment.BlogId);
        }

        public ActionResult About()
        {
            About about = aboutManager.GetAboutList().FirstOrDefault();
            return View(about);
        }

    }
}