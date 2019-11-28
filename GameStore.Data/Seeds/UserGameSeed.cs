using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class UserGameSeed
    {
        public static void SeedUserGames(this ModelBuilder builder)
        {
           // builder.Entity<UserGame>().HasData(
           //    new UserGame
           //    {
           //       UserId = "2a2a222-222-22aa-222a-a22aa2a22aa2",
           //       GameId = Guid.Parse("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
           //       PurchaseDate = DateTime.UtcNow
           //    }
           //);
        }
    }
}
