using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gamblingSite.Models
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;

        public AppDBContext(DbContextOptions<AppDBContext> options) :
        base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasKey(ar => new { ar.UserId, ar.SpinId });
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasOne(ar => ar.ApplicationUser)
                .WithMany(a => a.ApplicationUserRouletteModels)
                .HasForeignKey(ar => ar.UserId);
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasOne(ar => ar.RouletteModel)
                .WithMany(r => r.ApplicationUserRouletteModels)
                .HasForeignKey(ar => ar.SpinId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RouletteModel> RouletteModels { get; set; }
        public DbSet<ApplicationUserRouletteModel> ApplicationUserRouletteModels { get; set; }
    }
}
