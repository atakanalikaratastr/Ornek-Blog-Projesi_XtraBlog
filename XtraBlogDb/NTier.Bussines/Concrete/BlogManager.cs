using NTier.Bussines.Abstract;
using NTier.DataAccess.Abstract;
using NTier.DataAccess.Concrete.EntityFramework;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDAL;
        ITagService _tagService;

        public BlogManager(IBlogDAL blogDAL, ITagService tagService)
        {
            _blogDAL = blogDAL;
            _tagService = tagService;

        }
        public void Add(Blog blog)
        {

            _blogDAL.Add(blog);

        }

        public void BlogToTagAdd(int blogId, int tagId)
        {
            _blogDAL.BlogToTagAdd(blogId, tagId);
        }

        public void BlogToTagDelete(int blogId, int tagId)
        {
            _blogDAL.BlogToTagDelete(blogId, tagId);
        }

        public void BlogToTagUpdate(int oldBlogId, int oldTagId, int newBlogId, int newTagId)
        {
            _blogDAL.BlogToTagUpdate(oldBlogId, oldTagId, newBlogId, newTagId);
        }

        public void Delete(Blog blog)
        {
            _blogDAL.Delete(blog);
        }

        public Blog GetBlogByBlogId(int? id)
        {
            return _blogDAL.Get(x => x.BlogId == id);
        }

        public List<BlogDetailDTO> GetblogDetailList()
        {
            return _blogDAL.GetblogDetailList();
        }

        public List<Blog> GetBlogList()
        {
            return _blogDAL.GetAll();
        }

        public List<BlogToTag> GetBlogToTagByBlogIdList(int blogId)
        {
            return _blogDAL.GetBlogToTagByBlogIdList(blogId);
        }

        public List<BlogToTag> GetBlogToTagList()
        {
            return _blogDAL.GetBlogToTagList();
        }

        public void Update(Blog blog)
        {
            _blogDAL.Update(blog);
        }
    }
}
