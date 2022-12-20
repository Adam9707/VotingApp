using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Contracts
{
    public interface ICandidateRepository 
    {
        void AddCandidate(Candidate newCandidate);
        public ICollection<Candidate> GetCandidates();
        public void RefreshCandidatesListInCache();
        public Candidate GetCandidate(int candidateId);
        public void SaveChanges();
    }
}
