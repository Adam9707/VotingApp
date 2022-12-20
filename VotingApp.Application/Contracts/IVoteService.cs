using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.DataTransferObjects;

namespace VotingApp.Application.Contracts
{
    public interface IVoteService
    {
        public void Vote(VoteDTO voteDTO);
    }
}
