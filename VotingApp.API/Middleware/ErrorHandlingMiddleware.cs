using System.Text.Json;
using System.Text.Json.Serialization;
using VotingApp.API.Attributes;
using VotingApp.Application.Contracts;
using VotingApp.Application.DataTransferObjects;
using VotingApp.Application.Exceptions;
using VotingApp.Domain.Exceptions;

namespace VotingApp.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly IHttpResponseFactory responseFactory;

        public ErrorHandlingMiddleware(IHttpResponseFactory responseFactory)
        {
            this.responseFactory = responseFactory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);

            }
            catch(BadHttpRequestException e)
            {
                var httpResponse = responseFactory.CreateHttpResponse(e.Message);
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
            catch(KeyNotFoundException e)
            {
                var httpResponse = responseFactory.CreateHttpResponse(e.Message);
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
            catch(PersistenceException e)
            {
                var httpResponse = responseFactory.CreateHttpResponse(e.Message);
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
            catch (IncorrectArgumentException e)
            {
                var httpResponse = responseFactory.CreateHttpResponse(e.Message);
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
            catch (IncorrectActionException e)
            {
                var httpResponse = responseFactory.CreateHttpResponse(e.Message);
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
            catch(Exception e)
            {
                var httpResponse = responseFactory.CreateHttpResponse("Internal server error");
                context.Response.StatusCode = httpResponse.StatusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(httpResponse));
            }
        }
    }
}
