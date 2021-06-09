using DbUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace Intership.Filters
{
    public class DatabaseInitFilter : IStartupFilter
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseInitFilter> _logger;

        public DatabaseInitFilter(IConfiguration configuration, ILogger<DatabaseInitFilter> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            //EnsureDatabase.For.SqlDatabase(connectionString); //if i wanna create the database;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(_configuration.GetConnectionString("sqlConnection"))
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                _logger.LogInformation($"Mistakes occured while upgrading database\nError: {result.Error}");
            }
            
            return next;
        }
    }
}
