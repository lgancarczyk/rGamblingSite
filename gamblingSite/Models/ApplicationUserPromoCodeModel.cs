using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class ApplicationUserPromoCodeModel
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int PromoCodeId { get; set; }
        public PromoCodeModel PromoCodeModel { get; set; }

    }
}
