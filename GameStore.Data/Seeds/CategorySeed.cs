using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class CategorySeed
    {
        public static void SeedCategories(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
               new Category
               {
                   Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "FPS"
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
               },
               new Category
               {
                   Id = Guid.Parse("4f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "MMO"
               },
               new Category
               {
                   Id = Guid.Parse("5f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "Adventure"
               },
               new Category
               {
                   Id = Guid.Parse("6f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "Puzzle"
               },
               new Category
               {
                   Id = Guid.Parse("7f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "Combat"
               },
               new Category
               {
                   Id = Guid.Parse("8f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "RPG"
               },
               new Category
               {
                   Id = Guid.Parse("9f8fad5b-d9cb-469f-a165-70867728950e"),
                   Name = "Educational"
               }
           );
        }
    }
}
