using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Persistence.DbContexts;

namespace VotingApp.Persistence
{
    public static class MigrationInstaller
    {
        public static IServiceProvider AddVotingAppMigration(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<VotingAppDbContext>();
            var pendingMigrations = dbContext.Database.GetPendingMigrations();

            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }


            return serviceProvider;
        }
    }
}
