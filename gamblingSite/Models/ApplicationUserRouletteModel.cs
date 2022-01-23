using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class ApplicationUserRouletteModel
    {
        [Key]
        public int BetId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SpinId { get; set; }
        public RouletteModel RouletteModel { get; set; }
        public decimal Stake { get; set; }
        public string Colour { get; set; }
    }
}

//[Key]
//public int BetId { get; set; }
//public string UserId { get; set; }
//public ApplicationUser ApplicationUser { get; set; }
//public int SpinId { get; set; }
//public RouletteModel RouletteModel { get; set; }
//public decimal Stake { get; set; }
//public string Colour { get; set; }
