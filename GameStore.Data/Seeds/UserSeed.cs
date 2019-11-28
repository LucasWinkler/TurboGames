using GameStore.Data.Models;
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
            
        }

        /// <summary>
        /// Creates the applications roles, admin account and a user account for testing.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration, TurboGamesContext context)
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

            var user = new User
            {
                FirstName = "Turbo",
                LastName = "User",
                UserName = configuration.GetSection("UserSettings")["Username"],
                Email = configuration.GetSection("UserSettings")["Email"],
                EmailConfirmed = true,
                Gender = Gender.Other,
                DOB = DateTime.UtcNow,
                PaymentId = Guid.Parse("1c3e6619-7425-40de-944b-e07fc1f90ae7")
            };

            string adminPassword = configuration.GetSection("AdminSettings")["Password"];
            string userPassword = configuration.GetSection("UserSettings")["Password"];

            var _admin = await UserManager.FindByEmailAsync(configuration.GetSection("AdminSettings")["Email"]);
            if (_admin == null)
            {
                var createAdmin = await UserManager.CreateAsync(admin, adminPassword);
                if (createAdmin.Succeeded)
                {
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }

            var _user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["Email"]);
            if (_user == null)
            {
                var createUser = await UserManager.CreateAsync(user, userPassword);
                if (createUser.Succeeded)
                {
                    var addRoleToUser = await UserManager.AddToRoleAsync(user, "Member");
                    if (addRoleToUser.Succeeded)
                    {
                        context.UserGames.Add(
                            new UserGame
                            {
                                UserId = user.Id,
                                GameId = Guid.Parse("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                                PurchaseDate = DateTime.UtcNow
                            });
                        await context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
