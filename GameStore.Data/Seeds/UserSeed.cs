using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GameStore.Data.Seeds
{
    public static class UserSeed
    {
        public static void SeedUsers(this ModelBuilder builder)
        {
            // TODO: Seed a user with games owned and all settings filled out.
            // var hasher = new PasswordHasher<User>(); // Password hasher
        }

        /// <summary>
        /// Creates the applications user roles and admin user.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin", "Member" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var admin = new User
            {
                FirstName = "Turbo",
                LastName = "Admin",
                UserName = configuration.GetSection("AdminSettings")["Username"],
                Email = configuration.GetSection("AdminSettings")["Email"],
                EmailConfirmed = true,
                Gender = Gender.Other,
                DOB = DateTime.UtcNow,
                PaymentId = Guid.Parse("1c3e6619-7425-40de-944b-e07fc1f90ae7")
            };

            string password = configuration.GetSection("AdminSettings")["Password"];

            var _user = await UserManager.FindByEmailAsync(configuration.GetSection("AdminSettings")["Email"]);
            if (_user == null)
            {
                var createAdmin = await UserManager.CreateAsync(admin, password);
                if (createAdmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
