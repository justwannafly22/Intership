using Contracts.Logger;
using DbUp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Intership.Filters
{
    public class DatabaseInitFilter : IStartupFilter
    {

        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;

        public DatabaseInitFilter(IConfiguration configuration, ILoggerManager logger)
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
                _logger.LogInfo($"Mistakes occured while upgrading database\nError: {result.Error}");
            }

            return next;
        }
    }
}
