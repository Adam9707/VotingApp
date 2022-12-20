using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.DataTransferObjects
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Votes { get; set; }
    }
}
