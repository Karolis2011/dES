using dES.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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

        private Task Seed(dESContext dataContext)
        {
            // TODO: Seed database

            // https://git.kkarolis.lt/InfoSA/KTUSA-PS/src/branch/master/KTUSAPS/Services/DatabaseInitializationService.cs


            return Task.CompletedTask;
        }
    }
}
