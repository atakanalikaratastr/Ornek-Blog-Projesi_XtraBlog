using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }

        public Tag()
        {
            this.Blogs = new HashSet<Blog>();
        }
    }
}
