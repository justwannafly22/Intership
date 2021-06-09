using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Reflection;

namespace DbUp
{
    class DpUp
    {
        
        public static IConfiguration Configuration { get; }

        static int Main(string[] args)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
        #if DEBUG
                Console.ReadLine();
        #endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
