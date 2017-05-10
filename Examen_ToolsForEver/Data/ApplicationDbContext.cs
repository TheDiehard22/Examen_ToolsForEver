using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Examen_ToolsForEver.Models;

namespace Examen_ToolsForEver.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Locatie> Locaties { get; set; }
        public DbSet<Fabrikant> Fabrikanten { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ProductLocatie>()
                .HasKey(t => new { t.ProductID, t.LocatieID });

            builder.Entity<ProductLocatie>()
                .HasOne(l => l.Locatie)
                .WithMany(l => l.ProductLocaties)
                .HasForeignKey(l => l.LocatieID);

            builder.Entity<ProductLocatie>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductLocaties)
                .HasForeignKey(p => p.ProductID);
        }

        public DbSet<Examen_ToolsForEver.Models.ProductLocatie> ProductLocatie { get; set; }
    }
}
