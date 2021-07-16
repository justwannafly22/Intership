using Intership.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Intership.Tests
{
    public class MSSQL_WebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder) //this method will run after calling at first time method GetRequiredService
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<MyDbContext>));

                services.Remove(descriptor);

                services.AddDbContext<MyDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();

                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<MyDbContext>();
                var logger = scopedServices.
                    GetRequiredService<ILogger<MSSQL_WebApplicationFactory<TStartup>>>();

                db.Database.EnsureCreated();
            });
        }
    }
}
