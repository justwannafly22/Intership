using Contracts.DbUp;
using Contracts.Logger;
using DbUp;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace DbUp
{

    class DpUp : IDbUp
    {
        public static IConfiguration Configuration { get; }

        private readonly ILoggerManager _logger;

        public DpUp(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void Upgrade()
        {
            //EnsureDatabase.For.SqlDatabase(connectionString); //if i wanna create the database;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(Configuration.GetConnectionString("sqlConnection"))
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                _logger.LogInfo($"Mistakes occured while upgrading database\nError: {result.Error}");
            }
        }
    }
}
