using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.DataTransferObjects
{
    public class VoteDTO
    {
        public int VoterId { get; set; }
        public int CandidateId { get; set; }
    }
}
