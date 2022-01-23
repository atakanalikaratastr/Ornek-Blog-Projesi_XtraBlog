using Core.DataAccess;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.DataAccess.Abstract
{
    public interface IBlogDAL : IRepository<Blog>
    {
        void BlogToTagAdd(int blogId, int tagId);
        void BlogToTagUpdate(int oldBlogId, int oldTagId, int newBlogId, int newTagId);
        void BlogToTagDelete(int blogId, int tagId);
        List<BlogToTag> GetBlogToTagByBlogIdList(int blogId);
        List<BlogToTag> GetBlogToTagList();
        List<BlogDetailDTO> GetblogDetailList();
    }
}
