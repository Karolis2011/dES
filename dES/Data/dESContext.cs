using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OperatingSystem = dES.Data.Model.OperatingSystem;

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
                .HasMany(r => r.Laptops)
                .WithOne(l => l.RAM);

            //builder.Entity<Laptop>()
            //    .HasOne(l => l.Product)
            //    .WithMany(p => p.Laptops);

            OperatingSystem[] OS = new OperatingSystem[]
            {
                 new OperatingSystem
                {
                    Id = 1,
                    Name = "Linux"
                },
                new OperatingSystem
                {
                    Id = 2,
                    Name = "Window 10"
                },
                new OperatingSystem
                {
                    Id = 3,
                    Name = "macOS"
                }
            };

            Brand[] brands = new Brand[]
            {
                 new Brand
                {
                    Id = 1,
                    Name = "Dell"
                },
                new Brand
                {
                    Id = 2,
                    Name = "HP"
                },
                new Brand
                {
                    Id = 3,
                    Name = "Apple"
                }
            };

            Processor[] proc = new Processor[]
            {
                new Processor
                {
                    Id=1,
                    Name="Intel core i7 9530",
                    Frequency="3ghz",
                    Cores=4
                },
                 new Processor
                {
                    Id=2,
                    Name="AMD ryzen 9",
                    Frequency="3.6ghz",
                    Cores=12
                },
                new Processor
                {
                    Id=3,
                    Name="Intel Core i9-9900K",
                    Frequency="4.8ghz",
                    Cores=12
                },
            };

            RAM[] rams = generateRAMs();

            int count = 10;
            Laptop[] laptop = generateLaptops(count, OS, brands, proc, rams);

            builder.Entity<OperatingSystem>().HasData(OS);
            builder.Entity<Brand>().HasData(brands);
            builder.Entity<Processor>().HasData(proc);
            builder.Entity<RAM>().HasData(rams);
            builder.Entity<Laptop>().HasData(laptop);
        }
        private RAM[] generateRAMs()
        {
            string[] freqs = new string[] { "2400MHz", "2133MHz", "1600MHz" };
            string[] mems = new string[] { "16gb", "8gb", "4gb" };
            RAM[] rams = new RAM[freqs.Length * mems.Length];
            int cnt = 0;
            for (int i = 0; i < freqs.Length; i++)
            {
                for (int j = 0; j < mems.Length; j++, cnt++)
                {
                    string freq = freqs[i];
                    string mem = mems[j];
                    rams[cnt] = new RAM
                    {
                        Id = cnt + 1,
                        Frequency = freq,
                        MemoryCapacity = mem
                    };
                }
            }
            return rams;
        }
        private Laptop[] generateLaptops(int count,
    OperatingSystem[] OS, Brand[] brands, Processor[] proc, RAM[] rams)
        {
            Laptop[] laptops = new Laptop[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int OSIndex = rand.Next(0, OS.Length);
                int brandIndex = rand.Next(0, brands.Length);
                int procIndex = rand.Next(0, proc.Length);
                int ramIndex = rand.Next(0, rams.Length);

                laptops[i] = new Laptop
                {
                    Id = i + 1,
                    OSId = OS[OSIndex].Id,
                    BrandId = brands[brandIndex].Id,
                    ProcessorId = proc[procIndex].Id,
                    RAMId = rams[ramIndex].Id
                };
            }
            return laptops;
        }

        public DbSet<ActionInformation> ActionInformation { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Model.OperatingSystem> OperatingSystems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPayment> OrderPayments { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductsOrders { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<RAM> RAMs { get; set; }
    }
}
