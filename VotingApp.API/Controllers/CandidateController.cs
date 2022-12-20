using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotingApp.API.Attributes;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Application.Responses;
using VotingApp.Domain.Entities;

namespace VotingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService candidateService;
        private readonly IHttpResponseFactory responseFactory;

        public CandidateController(ICandidateService candidateService, IHttpResponseFactory responseFactory)
        {
            this.candidateService = candidateService;
            this.responseFactory = responseFactory;
        }

        [HttpGet("candidates")]
     
        public IEnumerable<CandidateDTO> GetAllCandidates()
        {
            var result = candidateService.GetCandidates();
            return result;
        }
        [HttpPost("register-candidate")]
        [Logging("Register a candidate action")]
        public VotingAppHttpResponse RegisterCandidate([FromBody]RegisterRequestDTO dto)
        {
            candidateService.RegisterCandidate(dto);         
            return responseFactory.CreateHttpResponse("Candidate was registered successfully"); ;
        }
    }
}
