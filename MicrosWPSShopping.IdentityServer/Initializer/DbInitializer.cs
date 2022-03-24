using IdentityModel;
using Microsoft.AspNetCore.Identity;
using MicrosWPSShopping.IdentityServer.Configuration;
using MicrosWPSShopping.IdentityServer.Model;
using MicrosWPSShopping.IdentityServer.Model.Context;
using System.Security.Claims;

namespace MicrosWPSShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(SQLContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "Wellington-admin",
                Email = "wellington-admin@rocambole.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (41) 991597216",
                FirstName = "Wellingatão",
                LastName = "O bonitão",
            };

            _user.CreateAsync(admin, "Wellington123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "Wellington-client",
                Email = "wellington-client@rocambole.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (41) 991597216",
                FirstName = "Wellingatão",
                LastName = "O bonitão",
            };

            _user.CreateAsync(client, "Well123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
            }).Result;
        }
    }
}
