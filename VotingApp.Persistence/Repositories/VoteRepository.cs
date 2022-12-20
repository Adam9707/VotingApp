using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Contracts;
using VotingApp.Application.Exceptions;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;
using VotingApp.Persistence.DbContexts;

namespace VotingApp.Persistence.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly VotingAppDbContext context;

        public VoteRepository(VotingAppDbContext context)
        {
            this.context = context;
        }

        public void Vote(Voter voter, Candidate candidate)
        {
            var transation = context.Database.BeginTransaction();
            try
            {
                voter.Vote();
                candidate.AddVote();
                context.SaveChanges();
                transation.Commit();
            }catch(Exception e)
            {
                transation.Rollback();
                throw new PersistenceException("DB save error!");
            }
        }
    }
}
