using NTier.Bussines.Abstract;
using NTier.DataAccess.Abstract;
using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Bussines.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDAL _commentDAL;
        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }
        public void Add(Comment comment)
        {
            _commentDAL.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDAL.Delete(comment);
        }

        public Comment GetCommentByCommentId(int? id)
        {
            return _commentDAL.Get(x => x.CommentId == id);
        }

        public List<Comment> GetCommentList()
        {
            return _commentDAL.GetAll();
        }

        public void Update(Comment comment)
        {
            _commentDAL.Update(comment);
        }
    }
}
