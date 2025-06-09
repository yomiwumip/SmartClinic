using System;
using Microsoft.AspNetCore.TestHost;
using SmartClinic.API.Infrastructure.Fixtures;
using Xunit;
using Microsoft.AspNetCore.Hosting;

namespace SmartClinic.API.Specs
{
    [Collection(Collections.Database)]
    public abstract class DatabaseTestBase : IDisposable
    {
        protected DatabaseTestBase()
        {
            var hostBuilder = new WebHostBuilder()
                .UseStartup<TestStartup>();

                // Arrange
            Server = new TestServer(hostBuilder);
        }

        protected TestServer Server { get; }

        public void Dispose()
        {
            Server.Dispose();
        }
    }
}
