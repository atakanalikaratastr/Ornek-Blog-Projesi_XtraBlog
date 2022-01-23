using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetCommentList();
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
        Comment GetCommentByCommentId(int? id);

    }
}
