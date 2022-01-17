using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal MoneyAmount {get; set;}

        public ICollection<RouletteModel> Spins { get; set; }

    }
}
