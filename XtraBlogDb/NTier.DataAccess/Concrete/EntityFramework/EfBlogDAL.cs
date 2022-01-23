using Core.DataAccess.EntityFramework;
using NTier.DataAccess.Abstract;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DataAccess.Concrete.EntityFramework
{
    public class EfBlogDAL : RepositoryBase<Blog, NTier_Context>, IBlogDAL
    {
        public void BlogToTagAdd(int blogId, int tagId)
        {
            using (var context = new NTier_Context())
            {
                context.BlogToTag.Add(new BlogToTag { BlogId = blogId, TagId = tagId });
                context.SaveChanges();
            }
        }
        public void BlogToTagDelete(int blogId, int tagId)
        {
            using (var context = new NTier_Context())
            {
                var db = context.BlogToTag.Where(u => u.BlogId.Equals(blogId) && u.TagId.Equals(tagId)).FirstOrDefault();
                context.BlogToTag.Remove(db);
                context.SaveChanges();
            }
        }
        public void BlogToTagUpdate(int oldBlogId, int oldTagId, int newBlogId, int newTagId)
        {
            BlogToTagDelete(oldBlogId, oldTagId);
            BlogToTagAdd(newBlogId, newTagId);
        }
        public List<BlogDetailDTO> GetblogDetailList()
        {
            using (var context = new NTier_Context())
            {
                var result = from blog in context.Blogs
                             join user in context.Users
                             on blog.UserId equals user.UserId
                             join title in context.Titles
                             on user.TitleId equals title.TitleId
                             join category in context.Categories
                             on blog.CategoryId equals category.CategoryId
                             //join blogToTag in context.BlogToTag
                             //on blog.BlogId equals blogToTag.BlogId
                             //join tag in context.Tags
                             //on blogToTag.TagId equals tag.TagId
                             select new BlogDetailDTO
                             {
                                 BlogId = blog.BlogId,
                                 Title_Name = title.Name,
                                 User_Name = user.Name,
                                 User_Surname = user.Surname,
                                 CategoryName = category.Name,
                                 TagsList = context.Tags.Where(x=>x.TagId == context.BlogToTag.Where(cx => cx.BlogId == blog.BlogId && cx.TagId == x.TagId).FirstOrDefault().TagId).ToList(), /*context.BlogToTag.Where(x=>x.BlogId == blog.BlogId).ToList()*/
                                 Headline = blog.Headline,
                                 ContextText = blog.ContentText,
                                 Image = blog.Image,
                                 Date = blog.Date,
                                 Visiblity = blog.Visiblity
                             };
                return result.ToList();

                //var result = context.Blogs.Select(x => new Entities.BlogDetailDTO
                //{
                //    BlogId = x.BlogId,
                //    Title_Name = x.Users.FirstOrDefault(a=>a.TitleId == 1).Name,
                //    User_Name = x.Users.FirstOrDefault(a=>a.UserId == x.UserId).Name,
                //    User_Surname = x.Users.FirstOrDefault(a=>a.UserId == x.UserId).Surname,
                //    TagsList = /*x.BlogToTags.Where(a=>a.BlogId == x.BlogId).Select(b=> new Entities.Tag { TagId = b.TagId}).ToList()*/x.Tags.ToList(),
                //    Headline = x.Headline,
                //    ContextText = x.ContentText,
                //    Image = x.Image,
                //    Date = x.Date,
                //    Visiblity = x.Visiblity
                //}).ToList();
            }
        }
        //public string GetTitleName(int userId)
        //{
        //    using (var context = new NTier_Context())
        //    {
        //        var a = context.Users.FirstOrDefault(x=>x.UserId == userId);
        //        var b = context.Titles.FirstOrDefault(x=>x.TitleId == a.TitleId);

        //        return b.Name;
        //    }
        //}
        public List<BlogToTag> GetBlogToTagByBlogIdList(int blogId)
        {
            using (var context = new NTier_Context())
            {
                return context.BlogToTag.Where(x => x.BlogId == blogId).ToList();
            }
        }
        public List<BlogToTag> GetBlogToTagList()
        {
            using (var context = new NTier_Context())
            {
                return context.BlogToTag.ToList();
            }
        }
    }
}