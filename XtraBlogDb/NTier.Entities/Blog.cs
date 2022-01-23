using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class Blog
    {

        public int BlogId { get; set; }
        
        public int UserId { get; set; }
        [Display(Name = "Kategori Adı")]
        public int CategoryId { get; set; }
        [Display(Name = "Başlık")]
        public string Headline { get; set; }
        [Display(Name = "İçerik")]
        public string ContentText { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Yayında Mı ?")]
        public bool Visiblity { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Blog()
        {
            this.Tags = new HashSet<Tag>();
            this.Users = new HashSet<User>();
        }
    }
}
