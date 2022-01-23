using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class BlogDetailDTO
    {
        public int BlogId { get; set; }
        [Display(Name = "Kullanıcı Ünvan")]
        public string Title_Name { get; set; }
        [Display(Name = "Kullanıcı İsim")]
        public string User_Name { get; set; }
        [Display(Name = "Kullanıcı Soy İsim")]
        public string User_Surname { get; set; }
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [Display(Name = "Etiketler")]
        public List<Tag> TagsList { get; set; }
        [Display(Name = "Başlık")]
        public string Headline { get; set; }
        [Display(Name = "İçerik")]
        public string ContextText { get; set; }
        [Display(Name = "Resim")]
        public string Image { get; set; }
        [Display(Name = "Eklenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Date { get; set; }
        [Display(Name = "Yayında mı ?")]
        public bool Visiblity { get; set; }
    }
}
