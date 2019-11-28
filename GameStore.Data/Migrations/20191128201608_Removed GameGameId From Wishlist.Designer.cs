﻿// <auto-generated />
using System;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.Data.Migrations
{
    [DbContext(typeof(TurboGamesContext))]
    [Migration("20191128201608_Removed GameGameId From Wishlist")]
    partial class RemovedGameGameIdFromWishlist
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.Data.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("FullName")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("StateProvinceRegion")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("GameStore.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new { Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Name = "FPS" },
                        new { Id = new Guid("1f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Adventure" },
                        new { Id = new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Strategy" },
                        new { Id = new Guid("3f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Sports" },
                        new { Id = new Guid("4f8fad5b-d9cb-469f-a165-70867728950e"), Name = "MMO" },
                        new { Id = new Guid("5f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Adventure" },
                        new { Id = new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Puzzle" },
                        new { Id = new Guid("7f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Combat" },
                        new { Id = new Guid("8f8fad5b-d9cb-469f-a165-70867728950e"), Name = "RPG" },
                        new { Id = new Guid("9f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Educational" }
                    );
                });

            modelBuilder.Entity("GameStore.Data.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Classification");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("GameStore.Data.Models.Friendship", b =>
                {
                    b.Property<string>("SenderId");

                    b.Property<string>("ReceiverId");

                    b.Property<bool>("IsFamily");

                    b.Property<int>("RequestStatus");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("GameStore.Data.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Developer")
                        .IsRequired();

                    b.Property<Guid>("PlatformId");

                    b.Property<double>("Price");

                    b.Property<double>("Rating");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Game");

                    b.HasData(
                        new { Id = new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Counter-Strike: Global Offensive (CS:GO) is a multiplayer first-person shooter video game developed by Hidden Path Entertainment and Valve Corporation. It is the fourth game in the Counter-Strike series and was released for Microsoft Windows, OS X, Xbox 360, and PlayStation 3 on August 21, 2012, while the Linux version was released in 2014.", Developer = "Valve", PlatformId = new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), Price = 0.0, Rating = 0.0, Title = "Counter-Strike: Global Offensive" },
                        new { Id = new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Apex Legends is a free-to-play Battle Royale game where legendary competitors battle for glory, fame, and fortune on the fringes of the Frontier.", Developer = "Respawn", PlatformId = new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"), Price = 0.0, Rating = 0.0, Title = "Apex Legends" },
                        new { Id = new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Age of Empires II: The Age of Kings is a real-time strategy video game developed by Ensemble Studios and published by Microsoft. Released in 1999 for Microsoft Windows and Macintosh, it is the second game in the Age of Empires series.", Developer = "Forgotten Empires, Tantalus Media, Wicked Witch", PlatformId = new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), Price = 21.99, Rating = 0.0, Title = "Age of Empires II: Definitive Edition" }
                    );
                });

            modelBuilder.Entity("GameStore.Data.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CardCVC")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("CardExpirationDate")
                        .IsRequired();

                    b.Property<string>("CardName")
                        .IsRequired();

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.HasKey("Id");

                    b.ToTable("Payment");

                    b.HasData(
                        new { Id = new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), CardCVC = "313", CardExpirationDate = "11/21", CardName = "Lucas Winkler", CardNumber = "4123450131003312" }
                    );
                });

            modelBuilder.Entity("GameStore.Data.Models.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Platform");

                    b.HasData(
                        new { Id = new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Steam" },
                        new { Id = new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Origin" },
                        new { Id = new Guid("332a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Blizzard" },
                        new { Id = new Guid("432a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Playstation" },
                        new { Id = new Guid("532a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Xbox" },
                        new { Id = new Guid("632a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Nintendo" }
                    );
                });

            modelBuilder.Entity("GameStore.Data.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1250);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("GameId");

                    b.Property<double>("Rating");

                    b.Property<int>("ReviewStatus");

                    b.Property<string>("ReviewerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("GameStore.Data.Models.ShoppingCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsCheckedOut");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("GameStore.Data.Models.ShoppingCartGame", b =>
                {
                    b.Property<Guid>("CartId");

                    b.Property<Guid>("GameId");

                    b.Property<double>("Price");

                    b.HasKey("CartId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("CartGame");
                });

            modelBuilder.Entity("GameStore.Data.Models.UserAddress", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("AddressId");

                    b.HasKey("UserId", "AddressId");

                    b.HasIndex("AddressId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("GameStore.Data.Models.UserEvent", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("EventId");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("GameStore.Data.Models.UserGame", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("GameId");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGame");

                    b.HasData(
                        new { UserId = "2a2a222-222-22aa-222a-a22aa2a22aa2", GameId = new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), PurchaseDate = new DateTime(2019, 11, 28, 20, 16, 8, 213, DateTimeKind.Utc) }
                    );
                });

            modelBuilder.Entity("GameStore.Data.Models.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AlreadyExists");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("GameStore.Data.Models.WishlistGame", b =>
                {
                    b.Property<Guid>("WishlistId");

                    b.Property<Guid>("GameId");

                    b.Property<double>("Price");

                    b.HasKey("WishlistId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("WishlistGame");
                });

            modelBuilder.Entity("GameStore.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DOB");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid?>("FavouriteCategoryId");

                    b.Property<Guid?>("FavouritePlatformId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<Guid?>("PaymentId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("ShouldReceiveEmails");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("FavouriteCategoryId");

                    b.HasIndex("FavouritePlatformId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PaymentId");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = "2a2a222-222-22aa-222a-a22aa2a22aa2", AccessFailedCount = 0, ConcurrencyStamp = "a4f80cd7-0b03-450f-9961-5ef61bec2777", DOB = new DateTime(2019, 11, 28, 20, 16, 8, 210, DateTimeKind.Utc), Email = "user@turbogames.com", EmailConfirmed = true, FirstName = "Turbo", Gender = 2, LastName = "User", LockoutEnabled = false, NormalizedEmail = "USER@TURBOGAMES.COM", NormalizedUserName = "USER", PasswordHash = "AQAAAAEAACcQAAAAEHB4+pJtILM7VmY5GR9ne734u07MH3sT0StuTbMFAEhzXbr2NpweBhEmvwR4IjTs3g==", PaymentId = new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), SecurityStamp = "63f4ab7c-2480-4618-a847-7d56665c10e3", ShouldReceiveEmails = false, TwoFactorEnabled = false, UserName = "User" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("GameStore.Data.Models.Friendship", b =>
                {
                    b.HasOne("GameStore.Data.User", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.Models.Game", b =>
                {
                    b.HasOne("GameStore.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Data.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Data.Models.Review", b =>
                {
                    b.HasOne("GameStore.Data.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Data.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Data.Models.ShoppingCart", b =>
                {
                    b.HasOne("GameStore.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Data.Models.ShoppingCartGame", b =>
                {
                    b.HasOne("GameStore.Data.Models.ShoppingCart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.Models.UserAddress", b =>
                {
                    b.HasOne("GameStore.Data.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.Models.UserEvent", b =>
                {
                    b.HasOne("GameStore.Data.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.Models.UserGame", b =>
                {
                    b.HasOne("GameStore.Data.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.Models.Wishlist", b =>
                {
                    b.HasOne("GameStore.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Data.Models.WishlistGame", b =>
                {
                    b.HasOne("GameStore.Data.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.Models.Wishlist", "Wishlist")
                        .WithMany()
                        .HasForeignKey("WishlistId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Data.User", b =>
                {
                    b.HasOne("GameStore.Data.Models.Category", "FavouriteCategory")
                        .WithMany()
                        .HasForeignKey("FavouriteCategoryId");

                    b.HasOne("GameStore.Data.Models.Platform", "FavouritePlatform")
                        .WithMany()
                        .HasForeignKey("FavouritePlatformId");

                    b.HasOne("GameStore.Data.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GameStore.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GameStore.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GameStore.Data.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
