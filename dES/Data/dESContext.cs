using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dES.Data
{
    public class dESContext : IdentityDbContext<User>
    {
        public dESContext() : base() { }

        public dESContext(DbContextOptions<dESContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;User=des;Password=;Database=des_dev", new MariaDbServerVersion(new Version(10, 6, 3)));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            builder.Entity<RAM>()
                .HasOne(r => r.Laptop)
                .WithMany(l => l.RAMs);
        }

        public DbSet<ActionInformation> ActionInformation { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Laptop> Laptop { get; set; }
        public DbSet<Model.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrder { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<RAM> RAMs { get; set; }
    }
}
