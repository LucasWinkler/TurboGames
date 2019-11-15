using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class GameSeed
    {
        public static void SeedGames(this ModelBuilder builder)
        {
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
        }
    }
}
