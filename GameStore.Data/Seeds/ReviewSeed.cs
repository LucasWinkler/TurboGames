using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class ReviewSeed
    {
        public static void SeedReviews(this ModelBuilder builder)
        {
            // builder.Entity<Review>().HasData(
            //    new Review
            //    {
            //        Id = Guid.Parse("0c9e6a79-7425-409e-944b-e0791f99ae91"),
            //        Content = "Pretty good game.",
            //        GameId = Guid.Parse("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
            //        IsAccepted = false,
            //        ReviewerId = "2a2a222-222-22aa-222a-a22aa2a22aa2",
            //        Rating = 3,
            //        CreatedDate = DateTime.UtcNow
            //    }
            //);
        }
    }
}
