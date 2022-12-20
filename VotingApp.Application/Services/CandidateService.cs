using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.Services
{
    public class CandidateService:ICandidateService
    {
        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            this.candidateRepository = candidateRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CandidateDTO> GetCandidates()
        {
            var candidates = candidateRepository.GetCandidates();
            var result = mapper.Map<List<CandidateDTO>>(candidates);
            return result;
        }
        public void RegisterCandidate(RegisterRequestDTO dto)
        {
            var newCandidate = new Candidate(dto.Name);
            candidateRepository.AddCandidate(newCandidate);
        }
    }
}
