using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Application.Responses;
using VotingApp.Application.Services;

namespace VotingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly IHttpResponseFactory responseFactory;

        public VoteController(IVoteService voteService, IHttpResponseFactory responseFactory)
        {
            this.voteService = voteService;
            this.responseFactory = responseFactory;
        }

        [HttpPost("vote")]
        public VotingAppHttpResponse RegisterCandidate([FromBody] VoteDTO dto)
        {
            voteService.Vote(dto);
            return responseFactory.CreateHttpResponse("Success");
        }
    }
}
