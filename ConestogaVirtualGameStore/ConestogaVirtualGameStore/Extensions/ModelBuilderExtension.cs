using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConestogaVirtualGameStore.Extensions
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
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Name = "Category Name",
                    Description = "Category Description"
                }
            );

            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = Guid.Parse("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Game Name 1",
                    Developer = "Game Developer 1",
                    CategoryId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Description = "The description"
                },
                new Game
                {
                    Id = Guid.Parse("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Game Name 2",
                    Developer = "Game Developer 2",
                    CategoryId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Description = "The description"
                },
                new Game
                {
                    Id = Guid.Parse("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Title = "Game Name 3",
                    Developer = "Game Developer 3",
                    CategoryId = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Description = "The description"
                }
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "4c9e6679-7425-40de-944b-e07fc1f90ae7",
                    FirstName = "Admin First",
                    LastName = "Admin Last ",
                    Gender = Gender.Male,
                    DOB = new DateTime(1998,10,12),
                    IsAdmin = true
                }
                );

            builder.Entity<UserGame>().HasData(
                new UserGame
                {
                   UserId = "4c9e6679-7425-40de-944b-e07fc1f90ae7",
                   GameId = Guid.Parse("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                },
                new UserGame
                {
                    UserId = "4c9e6679-7425-40de-944b-e07fc1f90ae7",
                    GameId = Guid.Parse("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                }
                );

        }
    }
}
