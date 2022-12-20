using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.DataTransferObjects
{
    public class VoterDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool HasVoted { get; set; }
    }
}
