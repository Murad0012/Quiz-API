using Microsoft.AspNetCore.Identity;
using WebApplication1.Entities;

namespace WebApplication1.Helper
{
    public class DataSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {

            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string[] roles = new[] { "Admin", "User" };

                foreach (string role in roles)
                {
                    var exists = await roleManager.RoleExistsAsync(role);
                    if (exists) continue;
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                var user = new AppUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "admin@mail.com",
                    UserName = "Admin",
                };

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var existingUser = await userManager.FindByNameAsync("Admin");
                if (existingUser is not null) return;

                await userManager.CreateAsync(user, "admin12345");
                await userManager.AddToRoleAsync(user, roles[0]);

                return;
            }
        }
    }
}
