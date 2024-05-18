using Microsoft.AspNetCore.Identity;

namespace FastCell.Helpers.Seeders.RoleSeeder
{
    public class RoleSeeder : IRoleSeeder
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly string[] roles = ["Admin", "Manager", "User"];

        public RoleSeeder(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
