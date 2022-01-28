using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class PromoCodeViewModel
    {
        public string PromoCode { get; set; }
        public decimal CodeValue { get; set; }
        public bool IsCodeActive { get; set; }
        public IList<PromoCodeModel> PromoCodeModels { get; set; }

    }
}
