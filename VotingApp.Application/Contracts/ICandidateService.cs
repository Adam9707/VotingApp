using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;

namespace VotingApp.Application.Contracts
{
    public interface ICandidateService
    {
        public IEnumerable<CandidateDTO> GetCandidates();
        public void RegisterCandidate(RegisterRequestDTO dto);
    }
}
