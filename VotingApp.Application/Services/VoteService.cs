using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;

namespace VotingApp.Application.Services
{
    public class VoteService:IVoteService
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IVoterRepository voterRepository;
        private readonly IVoteRepository voteRepository;

        public VoteService(ICandidateRepository candidateRepository, IVoterRepository voterRepository,IVoteRepository voteRepository)
        {
            this.candidateRepository = candidateRepository;
            this.voterRepository = voterRepository;
            this.voteRepository = voteRepository;
        }

        public void Vote(VoteDTO voteDTO)
        {
            var voter = voterRepository.GetVoter(voteDTO.VoterId);
            var candidate = candidateRepository.GetCandidate(voteDTO.CandidateId);

            if(voter is null || candidate is null)
            {
                throw new KeyNotFoundException("Voter or candidate doesnt exist");
            }

            voteRepository.Vote(voter, candidate);

            candidateRepository.RefreshCandidatesListInCache();

        }
    }
}
