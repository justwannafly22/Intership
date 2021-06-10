using DbUp;
using Intership.Abstracts;
using Intership.Abstracts.Repositories;
using Intership.Data;
using Intership.Filters;
using Intership.Models.Entities;
using LoggerService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intership.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<MyDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("Intership")));

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureFilters(this IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, DatabaseInitFilter>();
        }

        public static void ConfigureData(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
        }

    }
}
