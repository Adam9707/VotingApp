using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.Responses
{
    public abstract class VotingAppHttpResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
