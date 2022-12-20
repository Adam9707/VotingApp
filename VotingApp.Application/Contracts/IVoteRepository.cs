using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Contracts
{
    public interface IVoteRepository
    {
        public void Vote(Voter voter, Candidate candidate);
    }
}
