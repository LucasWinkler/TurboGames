using GameStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GameStore.Data.Seeds
{
    public static class PlatformSeed
    {
        public static void SeedPlatforms(this ModelBuilder builder)
        {
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
                },
                new Platform
                {
                    Id = Guid.Parse("432a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Playstation"
                },
                new Platform
                {
                    Id = Guid.Parse("532a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Xbox"
                },
                new Platform
                {
                    Id = Guid.Parse("632a91dd-d200-4c19-a767-f936cfbd8314"),
                    Name = "Nintendo"
                }
            );
        }
    }
}
