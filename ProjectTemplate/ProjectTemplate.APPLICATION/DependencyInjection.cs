using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.APPLICATION.Commands.SomeCommands.Something;
using ProjectTemplate.APPLICATION.Infrastructure.AutoMapper;
using ProjectTemplate.APPLICATION.Infrastructure.Behaviors;
using ProjectTemplate.APPLICATION.Infrastructure.Sieve;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectTemplate.APPLICATION
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();

            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddMediatR(typeof(AddSomethingCommandHandler).GetTypeInfo().Assembly);            
        }
    }
}

