using dES.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using dES.Data.Model;
using OperatingSystem = dES.Data.Model.OperatingSystem;

namespace dES.Services
{
    public class DatabaseInitializationService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<DatabaseInitializationService> logger;

        public DatabaseInitializationService(IServiceProvider serviceProvider, ILogger<DatabaseInitializationService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<dESContext>();
            var migrations = (await dataContext.Database.GetPendingMigrationsAsync(cancellationToken: cancellationToken)).ToList();
            if (migrations.Any())
            {
                logger.LogInformation($"There are {migrations.Count} pending migrations. Applying them");
                try
                {
                    await dataContext.Database.MigrateAsync(cancellationToken: cancellationToken);
                    await Seed(dataContext);
                }
                catch (Exception ex)
                {
                    logger.LogError("Migration failed. Database may be corrupt!");
                    logger.LogError(ex, "Migration failed.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task Seed(dESContext dataContext)
        {
            // TODO: Seed database

            // https://git.kkarolis.lt/InfoSA/KTUSA-PS/src/branch/master/KTUSAPS/Services/DatabaseInitializationService.cs
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
            var rams = generateRAMs();
            Laptop[] laptops = generateLaptops(10, OS, brands, proc, rams);

            await dataContext.RAMs.AddRangeAsync(rams);
            await dataContext.OperatingSystems.AddRangeAsync(OS);
            await dataContext.Brands.AddRangeAsync(brands);
            await dataContext.Processors.AddRangeAsync(proc);
            await dataContext.Laptops.AddRangeAsync(laptops);


            return;
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
Data.Model.OperatingSystem[] OS, Brand[] brands, Processor[] proc, RAM[] rams)
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
    }
}
