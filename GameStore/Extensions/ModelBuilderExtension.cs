using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Extensions
{
    /// <summary>
    /// Extension class for the Model Builder.
    /// Used to seperate data seeding.
    /// </summary>
    public static class ModelBuilderExtension
    {
        /// <summary>
        /// Seeds data for testing purposes.
        /// You must add a new migration when modifying this.
        /// </summary>
        /// <param name="builder"></param>
        public static void Seed(this ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Action"
                },
                new Category
                {
                    Id = Guid.Parse("1f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Adventure"
                },
                new Category
                {
                    Id = Guid.Parse("2f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Strategy"
                },
                new Category
                {
                    Id = Guid.Parse("3f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Sports"
                }
            );

            builder.Entity<Platform>().HasData(
                new Platform
                {
                    Id = Guid.Parse("132a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Steam"
                },
                new Platform
                {
                    Id = Guid.Parse("232a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Origin"
                },
                new Platform
                {
                    Id = Guid.Parse("332a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Blizzard"
                }
            );

            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = Guid.Parse("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Counter-Strike: Global Offensive",
                    Developer = "Valve",
                    CategoryId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    PlatformId = Guid.Parse("132a91dd-d200-4c19-a767-f936cfbd8314"),
                    Price = 0.00,
                    Description = "Counter-Strike: Global Offensive (CS:GO) is a multiplayer first-person shooter video game developed by Hidden Path Entertainment and Valve Corporation. It is the fourth game in the Counter-Strike series and was released for Microsoft Windows, OS X, Xbox 360, and PlayStation 3 on August 21, 2012, while the Linux version was released in 2014."
                },
                new Game
                {
                    Id = Guid.Parse("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Apex Legends",
                    Developer = "Respawn",
                    CategoryId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    PlatformId = Guid.Parse("232a91dd-d200-4c19-a767-f936cfbd8314"),
                    Price = 0.00,
                    Description = "Apex Legends is a free-to-play Battle Royale game where legendary competitors battle for glory, fame, and fortune on the fringes of the Frontier."
                },
                new Game
                {
                    Id = Guid.Parse("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Age of Empires II: Definitive Edition",
                    Developer = "Forgotten Empires, Tantalus Media, Wicked Witch",
                    CategoryId = Guid.Parse("2f8fad5b-d9cb-469f-a165-70867728950e"),
                    PlatformId = Guid.Parse("132a91dd-d200-4c19-a767-f936cfbd8314"),
                    Price = 21.99,
                    Description = "Age of Empires II: The Age of Kings is a real-time strategy video game developed by Ensemble Studios and published by Microsoft. Released in 1999 for Microsoft Windows and Macintosh, it is the second game in the Age of Empires series."
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1a1a111-111-11aa-111a-a11aa1a11aa1",
                    UserName = "Admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "admin@gmail.com".ToUpper(),
                    NormalizedUserName = "Admin".ToUpper(),
                    PhoneNumber = null,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Turbo",
                    LastName = "Admin",
                    Gender = Gender.Other,
                    DOB = DateTime.UtcNow,
                    IsAdmin = true
                },
                new ApplicationUser
                {
                    Id = "2a2a222-222-22aa-222a-a22aa2a22aa2",
                    UserName = "User",
                    Email = "standard.user@gmail.com",
                    EmailConfirmed = true,
                    NormalizedEmail = "standard.user@gmail.com".ToUpper(),
                    NormalizedUserName = "User".ToUpper(),
                    PhoneNumber = null,
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "User123!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Turbo",
                    LastName = "User",
                    Gender = Gender.Other,
                    DOB = DateTime.UtcNow,
                    IsAdmin = false
                }
            );

            builder.Entity<Friendship>().HasData(
                new Friendship
                {
                    SenderId = "1a1a111-111-11aa-111a-a11aa1a11aa1",
                    ReceiverId = "2a2a222-222-22aa-222a-a22aa2a22aa2",
                    IsFamily = false,
                    RequestStatus = FriendStatusCode.Accepted
                }
            );
        }
    }
}
