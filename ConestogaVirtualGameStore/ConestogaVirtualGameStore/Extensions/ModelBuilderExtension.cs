﻿using ConestogaVirtualGameStore.Data;
using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;
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
            var hasher = new PasswordHasher<ApplicationUser>();

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
                    LastName = "Games",
                    Gender = Gender.Other,
                    DOB = DateTime.UtcNow,
                    IsAdmin = true
                }
            );
        }
    }
}
