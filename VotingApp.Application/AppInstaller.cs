using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VotingApp.Application.Contracts;
using VotingApp.Application.Services;
using VotingApp.Application.Responses;

namespace VotingApp.Application
{
    public static class AppInstaller
    {
        public static IServiceCollection AddVaotinAppApplication(this IServiceCollection services)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IVoterService, VoterService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IHttpResponseFactory, HttpResponsesFactory>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
