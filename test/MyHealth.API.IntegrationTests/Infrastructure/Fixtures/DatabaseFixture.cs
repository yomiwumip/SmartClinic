using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartClinic.Data;

namespace SmartClinic.API.Infrastructure.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        private readonly DbContextOptionsBuilder<SmartClinicContext> _SmartClinicOptionsBuilder;

        public DatabaseFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            builder.AddEnvironmentVariables();
            var configuration = builder.Build();

            _SmartClinicOptionsBuilder = new DbContextOptionsBuilder<SmartClinicContext>();
            _SmartClinicOptionsBuilder.UseSqlServer(configuration["Data:DefaultConnection:ConnectionString"]);

            var SmartClinicContext = new SmartClinicContext(_SmartClinicOptionsBuilder.Options);

            // Ensure the test database is deleted before starting the tests
            SmartClinicContext.Database.EnsureDeleted();
        }

        public void Dispose()
        {
            // Ensure the test database is deleted after all database test had run
            new SmartClinicContext(_SmartClinicOptionsBuilder.Options).Database.EnsureDeleted();
        }
    }
}
