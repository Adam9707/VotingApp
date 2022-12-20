using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Common;
using VotingApp.Application.Responses;

namespace VotingApp.Application.Contracts
{
    public interface IHttpResponseFactory
    {
        public VotingAppHttpResponse CreateHttpResponse(string message, ResponseType type = ResponseType.Success);
    }
}
