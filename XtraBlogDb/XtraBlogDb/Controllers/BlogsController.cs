using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NTier.Bussines.Concrete;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;

namespace XtraBlogDb.Controllers
{
    public class BlogsController : Controller
    {
        //private NTier_Context db = new NTier_Context();
        BlogManager blogManager = new BlogManager(new EfBlogDAL(), new TagManager(new EfTagDAL()));
        TagManager TagManager = new TagManager(new EfTagDAL());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDAL());
        TitleManager titleManager = new TitleManager(new EfTitleDAL());
        [Authorize]
        // GET: Blogs
        public ActionResult Index()
        {

            return View(blogManager.GetblogDetailList());
        }

        // GET: Blogs/Details/5
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
            ViewBag.TitleName = titleManager.GetTitleByTitleId(blog.UserId);
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in categoryManager.GetCategoryList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.CategoryList = deger1;

            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file,[Bind(Include = "BlogId,UserId,CategoryId,Headline,ContentText,Image,Date,Visiblity")] Blog blog, string tagsName, Tag tag, BlogToTag blogToTag)
        {
            string ResimAdi;
            string adres;
            if (file != null)
            {
                ResimAdi = System.IO.Path.GetFileName(file.FileName);
                adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                blog.Image = ResimAdi;
            }
            if (ModelState.IsValid)
            {
                if (tagsName != null || tagsName != "")
                {
                    string[] tagsNameList = tagsName.Split(',');
                    foreach (var item in tagsNameList)
                    {
                        if (TagManager.GetTagByTagName(item) != item)
                        {
                            tag.Name = item;
                            TagManager.Add(tag);
                        }
                    }
                    blog.Date = DateTime.Now.Date;
                    blogManager.Add(blog);
                    foreach (var item in tagsNameList)
                    {
                        int tagId = TagManager.GetTagNameByTagId(item);
                        blogManager.BlogToTagAdd(blog.BlogId, tagId);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
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
            List<SelectListItem> deger1 = (from i in categoryManager.GetCategoryList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.CategoryId.ToString()
                                           }).ToList();
            ViewBag.CategoryList = deger1;
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file,[Bind(Include = "BlogId,UserId,CategoryId,Headline,ContentText,Image,Date,Visiblity")] Blog blog, string tagsName, Tag tag, BlogToTag blogToTag)
        {
            string ResimAdi;
            string adres;
            var blogGet = blogManager.GetBlogByBlogId(blog.BlogId);
            string onceki = blogGet.Image;
            if (file != null)
            {
                ResimAdi = System.IO.Path.GetFileName(file.FileName);
                adres = Server.MapPath("~/images/" + ResimAdi);
                file.SaveAs(adres);

                blog.Image = ResimAdi;
            }
            else
            {
                blog.Image = onceki;
            }
            if (ModelState.IsValid)
            {
                if (tagsName != null || tagsName != "")
                {
                    string[] tagsNameList = tagsName.Split(',');
                    foreach (var item in tagsNameList)
                    {
                        if (TagManager.GetTagByTagName(item) != item)
                        {
                            tag.Name = item;
                            TagManager.Add(tag);
                        }
                    }
                    blogManager.Update(blog);
                    foreach (var item in blogManager.GetBlogToTagByBlogIdList(blog.BlogId))
                    {
                        blogManager.BlogToTagDelete(item.BlogId, item.TagId);
                    }
                    foreach (var item in tagsNameList)
                    {
                        int tagId = TagManager.GetTagNameByTagId(item);
                        blogManager.BlogToTagAdd(blog.BlogId, tagId);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
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
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = blogManager.GetBlogByBlogId(id);
            foreach (var item in blogManager.GetBlogToTagByBlogIdList(blog.BlogId))
            {
                blogManager.BlogToTagDelete(item.BlogId, item.TagId);
            }
            blogManager.Delete(blog);
            return RedirectToAction("Index");
        }
    }
}
