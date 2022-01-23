using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Display(Name = "Ünvan Adı")]
        public int TitleId { get; set; }
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
