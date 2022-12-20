using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.Responses
{
    public class HttpResponseBadRequest : VotingAppHttpResponse
    {
        public HttpResponseBadRequest(string message)
        {
            this.StatusCode = 400;
            this.Message = message;
        }
    }
}
