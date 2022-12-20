using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using VotingApp.API.Attributes;

namespace VotingApp.API.Middleware
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger logger;

        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
          
            var loggingAttribute = context.GetEndpoint().Metadata.GetMetadata<LoggingAttribute>();
            if (loggingAttribute != null)
            {
                logger.LogInformation(loggingAttribute.Message);
            }
            await next.Invoke(context);
        }
    }
}
