﻿using Microsoft.AspNetCore.Identity;
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
            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = "2a2a222-222-22aa-222a-a22aa2a22aa2",
                    UserName = "User",
                    Email = "user@turbogames.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "user@turbogames.com".ToUpper(),
                    NormalizedUserName = "User".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "User123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Turbo",
                    LastName = "User",
                    Gender = Gender.Other,
                    DOB = DateTime.UtcNow,
                    PaymentId = Guid.Parse("1c3e6619-7425-40de-944b-e07fc1f90ae7")
                }
            );
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