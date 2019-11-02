using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.Data
{
    /// <summary>
    /// Used to query data and do any database related mappings.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for each model
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }

        /// <summary>
        /// Configures a given entity type in the model.
        /// Such as renaming the default table names for each model.
        /// </summary>
        /// <param name="builder">Used for constructing a model for the context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .ToTable("User")
                .HasKey(x => x.Id);

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

            builder.Entity<Game>()
                .ToTable("Game");

            builder.Entity<GameReview>()
                .ToTable("GameReview")
                .HasKey(x => new { x.GameId, x.ReviewId });
        }
    }
}
