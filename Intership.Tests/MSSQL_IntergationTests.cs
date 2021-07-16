using Intership.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Intership.Tests
{
    public class MSSQL_IntergationTests<TStartup> : IDisposable where TStartup : class
    {
        protected HttpClient Client { get; private set; }

        private readonly MSSQL_WebApplicationFactory<TStartup> _factory;
        protected List<Action> CleanupActions { get; set; }
        protected MyDbContextIdentity Context { get; private set; }

        public MSSQL_IntergationTests(MSSQL_WebApplicationFactory<TStartup> factory)
        {
            _factory = factory;
            Context = _factory.Services.GetRequiredService<MyDbContextIdentity>();
            Client = _factory.CreateClient();
            CleanupActions = new List<Action>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                foreach (var act in CleanupActions)
                {
                    act();
                }
                Client.Dispose();

                _disposed = true;
            }
        }
    }
}
