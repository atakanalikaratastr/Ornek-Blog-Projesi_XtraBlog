using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class UserDetailDTO
    {
        public int UserId { get; set; }
        [Display(Name = "Ünvan Adı")]
        public string Title_Name { get; set; }
        [Display(Name = "İsim")]
        public string Name { get; set; }
        [Display(Name = "Soyisim")]
        public string Surname { get; set; }
        [Display(Name = "E-Posta")]
        public string Mail { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Display(Name = "Açıklama")]
        public string Statement { get; set; }
    }
}
