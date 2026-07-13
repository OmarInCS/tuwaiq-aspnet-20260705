using Microsoft.AspNetCore.Identity;

namespace ClinicApp.Helpers {
    public class AdminSeeder {

        public static async Task SeedAdmin(WebApplication app) {
            var scope = app.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();


            var admin = await userManager.FindByEmailAsync("admin@clinic.com");

            if (admin != null) return;

            admin = new IdentityUser {
                Email = "admin@clinic.com",
                UserName = "admin"
            };

            var result = await userManager.CreateAsync(admin, "Admin@123456");

            if (!result.Succeeded) {
                throw new Exception("Can't create admin user");
            }
        }
    }
}
