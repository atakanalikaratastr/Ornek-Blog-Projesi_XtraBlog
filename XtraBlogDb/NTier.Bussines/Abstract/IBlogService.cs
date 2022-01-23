using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetBlogList();
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        Blog GetBlogByBlogId(int? id);
        void BlogToTagAdd(int blogId, int tagId);
        void BlogToTagDelete(int blogId, int tagId);
        void BlogToTagUpdate(int oldBlogId, int oldTagId, int newBlogId, int newTagId);
        List<BlogToTag> GetBlogToTagByBlogIdList(int blogId);
        List<BlogDetailDTO> GetblogDetailList();
        List<BlogToTag> GetBlogToTagList();

    }
}
