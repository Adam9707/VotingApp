using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.Exceptions
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string? message) : base(message)
        {
        }
    }
}
