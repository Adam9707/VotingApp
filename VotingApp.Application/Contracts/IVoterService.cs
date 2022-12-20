using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;

namespace VotingApp.Application.Contracts
{
    public interface IVoterService
    {
        public IEnumerable<VoterDTO> GetVoters();
        public void RegisterVoter(RegisterRequestDTO dto);
    }
}
