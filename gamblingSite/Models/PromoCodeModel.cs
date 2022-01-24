using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class PromoCodeModel
    {
        [Key]
        public int PromoCodeId { get; set; }
        public decimal CodeValue { get; set; }
        public ICollection<ApplicationUser> applicationUsers { get; set; }
    }
}
