using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    [Keyless]
    public class ApplicationUserRouletteModel
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SpinId { get; set; }
        public RouletteModel RouletteModel { get; set; }
        public decimal Stake { get; set; }
        public string Colour { get; set; }
    }
}
