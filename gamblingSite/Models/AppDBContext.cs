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
            //about creating relation between user and roulette
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasKey(ar => new {ar.BetId, ar.UserId, ar.SpinId });
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .Property(ar => ar.BetId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasOne(ar => ar.ApplicationUser)
                .WithMany(a => a.ApplicationUserRouletteModels)
                .HasForeignKey(ar => ar.UserId);
            modelBuilder.Entity<ApplicationUserRouletteModel>()
                .HasOne(ar => ar.RouletteModel)
                .WithMany(r => r.ApplicationUserRouletteModels)
                .HasForeignKey(ar => ar.SpinId);

            //about creating relation between user and promo code
            modelBuilder.Entity<ApplicationUserPromoCodeModel>()
                .HasKey(ap => new { ap.UserId, ap.PromoCodeId });
            modelBuilder.Entity<ApplicationUserPromoCodeModel>()
                .HasOne(ap => ap.ApplicationUser)
                .WithMany(a => a.ApplicationUserPromoCodeModels)
                .HasForeignKey(ap => ap.UserId);
            modelBuilder.Entity<ApplicationUserPromoCodeModel>()
                .HasOne(ap => ap.PromoCodeModel)
                .WithMany(p => p.ApplicationUserPromoCodeModels)
                .HasForeignKey(ap => ap.PromoCodeId);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<RouletteModel> RouletteModels { get; set; }
        public DbSet<ApplicationUserRouletteModel> ApplicationUserRouletteModels { get; set; }
        public DbSet<PromoCodeModel> PromoCodeModels { get; set; }
        public DbSet<ApplicationUserPromoCodeModel> ApplicationUserPromoCodeModels { get; set; }
    }
}
