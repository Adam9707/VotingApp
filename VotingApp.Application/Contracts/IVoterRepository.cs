using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Contracts
{
    public interface IVoterRepository
    {
        public IEnumerable<Voter> GetVoters();
        public void AddVoter(Voter newVoter);
        public Voter GetVoter(int voterId);
        public void SaveChanges();

    }
}
