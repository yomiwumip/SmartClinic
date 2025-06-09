using System.Threading.Tasks;
using Acheve.AspNetCore.TestHost.Security;
using SmartClinic.API.Infrastructure;
using SmartClinic.Model;
using Xunit;

namespace SmartClinic.API.Specs.DoctorsController
{
    public class CreateDoctors : DatabaseTestBase
    {
        private readonly Doctor _validDoctor = new Doctor
        {
            TenantId = 1,
            Address = ""
        };

        [Fact]
        public async Task Administrator_Can_Create_Doctors()
        {
            // Act
            var response = await Server.CreateRequest(Api.Post.Doctors)
                .WithIdentity(Identities.Administrator)
                .WithDefaultPostHeaders()
                .WithContent(_validDoctor)
                .PostAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Tenant_Can_Create_Doctors()
        {
            // Act
            var response = await Server.CreateRequest(Api.Post.Doctors)
                .WithIdentity(Identities.Tenant)
                .WithDefaultPostHeaders()
                .WithContent(_validDoctor)
                .PostAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Users_Can_Create_Doctors()
        {
            // Act
            var response = await Server.CreateRequest(Api.Post.Doctors)
                .WithDefaultPostHeaders()
                .WithContent(_validDoctor)
                .PostAsync();

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
