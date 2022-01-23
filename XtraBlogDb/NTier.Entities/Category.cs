using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Yayında Mı ? ")]
        public bool Visiblity { get; set; }
    }
}
