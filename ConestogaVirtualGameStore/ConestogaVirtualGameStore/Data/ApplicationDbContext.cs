using ConestogaVirtualGameStore.Extensions;
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
    public DbSet<UserGame> UserGames { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<UserEvent> UserEvents { get; set; }

    /// <summary>
    /// Configures a given entity type in the model.
    /// Such as renaming the default table names for each model.
    /// </summary>
    /// <param name="builder">Used for constructing a model for the context.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      #region Identity

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

      #endregion

      #region Other

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

      // Setup the composite key
      builder.Entity<Friendship>()
             .ToTable("Friendship")
             .HasKey(x => new { x.SenderId, x.ReceiverId });

      // Manually map the sender foreign key to modify the OnDelete option
      builder.Entity<Friendship>()
             .HasOne(x => x.Sender)
             .WithMany()
             .HasForeignKey(x => x.SenderId)
             .OnDelete(DeleteBehavior.Restrict);

      // Manually map the receiver foreign key to modify the OnDelete option
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

      #endregion

      builder.Seed();
    }
  }
}
