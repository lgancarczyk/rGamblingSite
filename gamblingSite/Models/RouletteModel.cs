using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class RouletteModel
    {
        [Key]
        public int SpinID { get; set; }
        public string Colour { get; set; }
        public DateTime SpinDate { get; set; }
        //public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<ApplicationUserRouletteModel> ApplicationUserRouletteModels { get; set; }
    }
}
