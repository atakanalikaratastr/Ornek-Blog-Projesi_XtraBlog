using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        [Display(Name = "Ünvan Adı")]
        public string Name { get; set; }
    }
}
