using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string Topic { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public bool Visiblity { get; set; }

    }
}
