using System.Collections.Generic;
using System.Security.Claims;

namespace SmartClinic.API
{
    public static class Identities
    {
        public static IEnumerable<Claim> Administrator = new[]
        {
            new Claim("ManageUsers", "Allowed"),
            new Claim("ManageTenants", "Allowed")
        };

        public static IEnumerable<Claim> Tenant = new[]
        {
            new Claim("ManageTenants", "Allowed")
        };

        public static IEnumerable<Claim> User = new Claim[0];
    }
}
