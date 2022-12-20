using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Domain.Entities;

namespace VotingApp.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Candidate, CandidateDTO>();
            CreateMap<Voter, VoterDTO>();
        }
    }
}
