using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingApp.Domain.Entities;

namespace VotingApp.Persistence.DbContexts
{
    public class VotingAppDbContext : DbContext
    {
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }


        public VotingAppDbContext(DbContextOptions<VotingAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>().Property(v => v.Name).IsRequired();
            modelBuilder.Entity<Voter>().Property(v => v.HasVoted).IsRequired();

            modelBuilder.Entity<Candidate>().Property(c => c.Name).IsRequired();
            modelBuilder.Entity<Candidate>().Property(c => c.Votes).IsRequired();
        }
    }
}
