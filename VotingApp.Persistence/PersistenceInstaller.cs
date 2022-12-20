using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Common;
using VotingApp.Application.Contracts;
using VotingApp.Persistence.DbContexts;
using VotingApp.Persistence.Repositories;

namespace VotingApp.Persistence
{
    public static class PersistenceInstaller
    {
        public static IServiceCollection AddVotingAppPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var VotingTestAppConnectionString = configuration.GetConnectionString(ConnectionStringName.VOTING_APP);

            services.AddMemoryCache();
            services.AddDbContext<VotingAppDbContext>(options => options.UseSqlServer(VotingTestAppConnectionString));
            services.AddScoped< ICandidateRepository ,CandidateRepository>();
            services.AddScoped<IVoterRepository, VoterRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            return services;
        }
    }
}
