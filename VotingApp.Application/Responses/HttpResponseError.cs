using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.Responses
{
    public class HttpResponseError : VotingAppHttpResponse
    {
        public HttpResponseError(string message)
        {
            this.StatusCode = 500;
            this.Message = message;
        }
    }
}
