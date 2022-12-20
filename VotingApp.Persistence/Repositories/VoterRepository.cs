using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;
using VotingApp.Persistence.DbContexts;

namespace VotingApp.Persistence.Repositories
{
    public class VoterRepository:IVoterRepository
    {
        private readonly VotingAppDbContext dbContext;
        ICandidateRepository candidateRepository;

        public VoterRepository(VotingAppDbContext dbContext, ICandidateRepository candidateRepository)
        {
            this.dbContext = dbContext;
            this.candidateRepository = candidateRepository;
        }

        public IEnumerable<Voter> GetVoters()
        {
            return dbContext.Voters.ToList();
        }

        public void AddVoter(Voter newVoter)
        {
            dbContext.Voters.Add(newVoter);
            dbContext.SaveChanges();
        }

        public Voter GetVoter(int voterId)
        {
            return dbContext.Voters.Find(voterId);
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
