using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApp.API.Attributes;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Application.Responses;
using VotingApp.Application.Services;

namespace VotingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterController : ControllerBase
    {
        private readonly IVoterService voterService;
        private readonly IHttpResponseFactory responseFactory;

        public VoterController(IVoterService voterService, IHttpResponseFactory responseFactory)
        {
            this.voterService = voterService;
            this.responseFactory = responseFactory;
        }
        [HttpGet("voters")]
        public IEnumerable<VoterDTO> GetAllVoters()
        {
            var result = voterService.GetVoters();
            return result;
        }
        [HttpPost("register-voter")]
        [Logging("Register voter action")]
        public VotingAppHttpResponse RegisterVoter([FromBody] RegisterRequestDTO dto)
        {
            voterService.RegisterVoter(dto);
            return responseFactory.CreateHttpResponse("Success");
        }
    }
}
