using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal WalletSize {get; set;}
        public virtual ICollection<ApplicationUserRouletteModel> ApplicationUserRouletteModels { get; set; }

    }
}
