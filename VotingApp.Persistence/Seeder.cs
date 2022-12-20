using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Domain.Entities;
using VotingApp.Persistence.DbContexts;

namespace VotingApp.Persistence
{
    public static class Seeder
    {
        public static IServiceProvider SeedVotingAppDb(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<VotingAppDbContext>();


            var voters = dbContext.Voters.ToList();
            var candidates = dbContext.Candidates.ToList();

            if (!voters.Any())
            {
                dbContext.Voters.AddRange(votersSeed);
                dbContext.SaveChanges();
            }
            if (!candidates.Any())
            {
                dbContext.Candidates.AddRange(candidatesSeed);
                dbContext.SaveChanges();
            }


            return serviceProvider;
        }

        private static List<Voter> votersSeed = new List<Voter>()
        {
            new Voter("Adam"),
            new Voter("Ania"),
            new Voter("Kasia"),
            new Voter("Dominik"),
            new Voter("Paula"),
            new Voter("Wiktor")
        };
        private static List<Candidate> candidatesSeed = new List<Candidate>()
        {
            new Candidate("Antoni"),
            new Candidate("Jan"),
            new Candidate("Aleksander"),
            new Candidate("Dominika"),
            new Candidate("Joanna"),
            new Candidate("Wiktoria")
        };
    }
}
