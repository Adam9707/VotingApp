using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Common;
using VotingApp.Application.Contracts;

namespace VotingApp.Application.Responses
{
    public class HttpResponsesFactory: IHttpResponseFactory
    {
        public VotingAppHttpResponse CreateHttpResponse(string message, ResponseType type = ResponseType.Success)
        {
            switch(type)
            {
                case ResponseType.Success:
                    return new HttpResponseSuccess(message);
                case ResponseType.Error:
                    return new HttpResponseError(message);
                case ResponseType.BadRequest: 
                    return new HttpResponseBadRequest(message);
                default: 
                    throw new InvalidOperationException();
            }
        }
    }
}
