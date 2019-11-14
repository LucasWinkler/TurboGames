using GameStore.Data.Models;
using GameStore.Data.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GameStore.Data
{
    /// <summary>
    /// Used to query data and do any database related mappings.
    /// </summary>
    public class TurboGamesContext : IdentityDbContext<User>
    {
        public TurboGamesContext(DbContextOptions<TurboGamesContext> options)
            : base(options)
        {
        }

        // DbSets for each model
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<ShoppingCartGame> CartGames { get; set; }

        private void SeedData(ModelBuilder builder)
        {
            builder.SeedUsers();
            builder.SeedPayments();

            builder.SeedCategories();
            builder.SeedPlatforms();
            builder.SeedGames();
            
            builder.SeedUserGames();
            builder.SeedReviews();
        }

        /// <summary>
        /// Configures a given entity type in the model.
        /// Such as renaming the default table names for each model.
        /// </summary>
        /// <param name="builder">Used for constructing a model for the context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                   .ToTable("User")
                   .HasKey(x => x.Id);

            builder.Entity<User>()
                .Ignore(x => x.PhoneNumber)
                .Ignore(x => x.PhoneNumberConfirmed);

            builder.Entity<IdentityRole>()
                   .ToTable("Role");

            builder.Entity<IdentityUserRole<string>>()
                   .ToTable("UserRole");

            builder.Entity<IdentityUserClaim<string>>()
                   .ToTable("UserClaim");

            builder.Entity<IdentityUserLogin<string>>()
                   .ToTable("UserLogin");

            builder.Entity<IdentityRoleClaim<string>>()
                   .ToTable("RoleClaim");

            builder.Entity<IdentityUserToken<string>>()
                   .ToTable("UserToken");

            builder.Entity<Address>()
                   .ToTable("Address");

            builder.Entity<Payment>()
                   .ToTable("Payment");

            builder.Entity<Review>()
                   .ToTable("Review");

            builder.Entity<Platform>()
                   .ToTable("Platform");

            builder.Entity<Category>()
                   .ToTable("Category");

            builder.Entity<Friendship>()
                   .ToTable("Friendship")
                   .HasKey(x => new { x.SenderId, x.ReceiverId });

            builder.Entity<Friendship>()
                   .HasOne(x => x.Sender)
                   .WithMany()
                   .HasForeignKey(x => x.SenderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friendship>()
                   .HasOne(x => x.Receiver)
                   .WithMany()
                   .HasForeignKey(x => x.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Game>()
                   .ToTable("Game");

            builder.Entity<UserGame>()
                   .ToTable("UserGame")
                   .HasKey(x => new { x.UserId, x.GameId });

            builder.Entity<UserGame>()
                   .HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserGame>()
                   .HasOne(x => x.Game)
                   .WithMany()
                   .HasForeignKey(x => x.GameId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                   .ToTable("Event");

            builder.Entity<UserEvent>()
                   .ToTable("UserEvent")
                   .HasKey(x => new { x.UserId, x.EventId });

            builder.Entity<UserEvent>()
                   .HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserEvent>()
                   .HasOne(x => x.Event)
                   .WithMany()
                   .HasForeignKey(x => x.EventId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShoppingCart>()
                   .ToTable("Cart");

            builder.Entity<ShoppingCartGame>()
                   .ToTable("CartGame")
                   .HasKey(x => new { x.CartId, x.GameId });

            builder.Entity<ShoppingCartGame>()
                   .HasOne(x => x.Cart)
                   .WithMany()
                   .HasForeignKey(x => x.CartId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ShoppingCartGame>()
                   .HasOne(x => x.Game)
                   .WithMany()
                   .HasForeignKey(x => x.GameId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserAddress>()
                   .ToTable("UserAddress")
                   .HasKey(x => new { x.UserId, x.AddressId });

            builder.Entity<UserAddress>()
                   .HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserAddress>()
                   .HasOne(x => x.Address)
                   .WithMany()
                   .HasForeignKey(x => x.AddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            SeedData(builder);
        }
    }
}
