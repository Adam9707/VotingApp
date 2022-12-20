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
    public class VoterService: IVoterService
    {
        private readonly IVoterRepository voterRepository;
        private readonly IMapper mapper;

        public VoterService(IVoterRepository voterRepository, IMapper mapper)
        {
            this.voterRepository = voterRepository;
            this.mapper = mapper;
        }

        public IEnumerable<VoterDTO> GetVoters()
        {
            var voters = voterRepository.GetVoters();
            var result = mapper.Map<List<VoterDTO>>(voters);
            return result;
        }
        public void RegisterVoter(RegisterRequestDTO dto)
        {
            var newVoter = new Voter(dto.Name);
            voterRepository.AddVoter(newVoter);
        }
    }
}
