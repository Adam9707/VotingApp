using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Domain.Exceptions
{
    public class IncorrectActionException : Exception
    {
        public IncorrectActionException(string message) : base(message)
        {
        }
    }
}
