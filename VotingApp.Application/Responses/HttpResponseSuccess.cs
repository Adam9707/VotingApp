using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp.Application.Responses
{
    public class HttpResponseSuccess : VotingAppHttpResponse
    {
        public HttpResponseSuccess(string message)
        {
            this.StatusCode = 200;
            this.Message = message;
        }
    }
}
