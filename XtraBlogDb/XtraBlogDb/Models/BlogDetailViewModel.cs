using NTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XtraBlogDb.Models
{
    public class BlogDetailViewModel
    {
        public Blog Blog { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}