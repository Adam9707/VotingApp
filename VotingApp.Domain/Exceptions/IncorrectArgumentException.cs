using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Domain.Exceptions
{
    public class IncorrectArgumentException : Exception
    {
        public IncorrectArgumentException(string message) : base(message)
        {
        }
    }
}
