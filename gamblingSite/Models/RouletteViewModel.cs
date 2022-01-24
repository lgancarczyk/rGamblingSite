using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class RouletteViewModel
    {
        public ApplicationUserRouletteModel applicationUserRouletteModel { get; set; }
        public RouletteModel rouletteModel { get; set; }
        public IList<RouletteModel> rouletteModels { get; set; }
        public IList<ApplicationUserRouletteModel> applicationUserRouletteModels { get; set; }
    }
}
