using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.APPLICATION.Interfaces.Persistence;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.CommandRepositories;
using ProjectTemplate.APPLICATION.Interfaces.Persistence.QueryRepositories;
using ProjectTemplate.PERSISTENCE.Repositories.Commands;
using ProjectTemplate.PERSISTENCE.Services.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTemplate.PERSISTENCE
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SomeDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ProjectTemplateDbConnection")));

            services.AddScoped<ISomeCommandRepository, SomeCommandRepository>();
            services.AddScoped<ISomeQueryService, SomeQueryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
