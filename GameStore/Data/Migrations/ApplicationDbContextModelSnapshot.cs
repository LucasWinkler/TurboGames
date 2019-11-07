﻿// <auto-generated />
using System;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameStore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameStore.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<Guid?>("AddressId");

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

                    b.Property<bool>("IsAdmin");

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

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("ShouldReceiveEmails");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

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
                        new { Id = "1a1a111-111-11aa-111a-a11aa1a11aa1", AccessFailedCount = 0, ConcurrencyStamp = "0672d3c4-2952-492d-b3b0-2e4c24e6083b", DOB = new DateTime(2019, 11, 7, 14, 0, 36, 195, DateTimeKind.Utc), Email = "admin@gmail.com", EmailConfirmed = true, FirstName = "Turbo", Gender = 2, IsAdmin = true, LastName = "Admin", LockoutEnabled = false, NormalizedEmail = "ADMIN@GMAIL.COM", NormalizedUserName = "ADMIN", PasswordHash = "AQAAAAEAACcQAAAAEHTJkov5pBlqJDYY2fSxFEyJTNiKT1qMq3Qgjf/cYrqASYjkxc6hmZLazDJ1T7DMUQ==", PhoneNumberConfirmed = true, SecurityStamp = "6e0a1376-7f24-42c3-befe-7196cbbaf539", ShouldReceiveEmails = false, TwoFactorEnabled = false, UserName = "Admin" },
                        new { Id = "2a2a222-222-22aa-222a-a22aa2a22aa2", AccessFailedCount = 0, ConcurrencyStamp = "c3809110-1e29-4fe7-847d-699d9a9bb817", DOB = new DateTime(2019, 11, 7, 14, 0, 36, 196, DateTimeKind.Utc), Email = "standard.user@gmail.com", EmailConfirmed = true, FirstName = "Turbo", Gender = 2, IsAdmin = false, LastName = "User", LockoutEnabled = false, NormalizedEmail = "STANDARD.USER@GMAIL.COM", NormalizedUserName = "USER", PasswordHash = "AQAAAAEAACcQAAAAENWUlTqqVBJ1dsdqkLs2h9cMcdDEPD+FOU/ff/FMMExJyHxZ43knghNUk8FlwclVLg==", PhoneNumberConfirmed = true, SecurityStamp = "e23ccfe6-824f-4155-9d7a-204b11232ea3", ShouldReceiveEmails = false, TwoFactorEnabled = false, UserName = "User" }
                    );
                });

            modelBuilder.Entity("GameStore.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("PrimaryAddress")
                        .IsRequired();

                    b.Property<string>("Province")
                        .IsRequired();

                    b.Property<string>("SecondaryAddress");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("GameStore.Models.Cart", b =>
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

            modelBuilder.Entity("GameStore.Models.CartGame", b =>
                {
                    b.Property<Guid>("CartId");

                    b.Property<Guid>("GameId");

                    b.Property<double>("Price");

                    b.HasKey("CartId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("CartGame");
                });

            modelBuilder.Entity("GameStore.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new { Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Action" },
                        new { Id = new Guid("1f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Adventure" },
                        new { Id = new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Strategy" },
                        new { Id = new Guid("3f8fad5b-d9cb-469f-a165-70867728950e"), Name = "Sports" }
                    );
                });

            modelBuilder.Entity("GameStore.Models.Event", b =>
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

            modelBuilder.Entity("GameStore.Models.Friendship", b =>
                {
                    b.Property<string>("SenderId");

                    b.Property<string>("ReceiverId");

                    b.Property<bool>("IsFamily");

                    b.Property<int>("RequestStatus");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Friendship");

                    b.HasData(
                        new { SenderId = "1a1a111-111-11aa-111a-a11aa1a11aa1", ReceiverId = "2a2a222-222-22aa-222a-a22aa2a22aa2", IsFamily = false, RequestStatus = 1 }
                    );
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
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

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TotalRating");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Game");

                    b.HasData(
                        new { Id = new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Counter-Strike: Global Offensive (CS:GO) is a multiplayer first-person shooter video game developed by Hidden Path Entertainment and Valve Corporation. It is the fourth game in the Counter-Strike series and was released for Microsoft Windows, OS X, Xbox 360, and PlayStation 3 on August 21, 2012, while the Linux version was released in 2014.", Developer = "Valve", PlatformId = new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), Price = 0.0, Title = "Counter-Strike: Global Offensive", TotalRating = 0 },
                        new { Id = new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Apex Legends is a free-to-play Battle Royale game where legendary competitors battle for glory, fame, and fortune on the fringes of the Frontier.", Developer = "Respawn", PlatformId = new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"), Price = 0.0, Title = "Apex Legends", TotalRating = 0 },
                        new { Id = new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), CategoryId = new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), Description = "Age of Empires II: The Age of Kings is a real-time strategy video game developed by Ensemble Studios and published by Microsoft. Released in 1999 for Microsoft Windows and Macintosh, it is the second game in the Age of Empires series.", Developer = "Forgotten Empires, Tantalus Media, Wicked Witch", PlatformId = new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), Price = 21.99, Title = "Age of Empires II: Definitive Edition", TotalRating = 0 }
                    );
                });

            modelBuilder.Entity("GameStore.Models.Payment", b =>
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
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("GameStore.Models.Platform", b =>
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
                        new { Id = new Guid("332a91dd-d200-4c19-a767-f936cfbd8314"), Name = "Blizzard" }
                    );
                });

            modelBuilder.Entity("GameStore.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("GameId");

                    b.Property<bool>("IsAccepted");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("GameStore.Models.UserEvent", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("EventId");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
                });

            modelBuilder.Entity("GameStore.Models.UserGame", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("GameId");

                    b.Property<DateTime>("PurchaseDate");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGame");
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

            modelBuilder.Entity("GameStore.Data.ApplicationUser", b =>
                {
                    b.HasOne("GameStore.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("GameStore.Models.Category", "FavouriteCategory")
                        .WithMany()
                        .HasForeignKey("FavouriteCategoryId");

                    b.HasOne("GameStore.Models.Platform", "FavouritePlatform")
                        .WithMany()
                        .HasForeignKey("FavouritePlatformId");

                    b.HasOne("GameStore.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("GameStore.Models.Cart", b =>
                {
                    b.HasOne("GameStore.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Models.CartGame", b =>
                {
                    b.HasOne("GameStore.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Models.Friendship", b =>
                {
                    b.HasOne("GameStore.Data.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Models.Game", b =>
                {
                    b.HasOne("GameStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Models.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Models.Review", b =>
                {
                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Data.ApplicationUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameStore.Models.UserEvent", b =>
                {
                    b.HasOne("GameStore.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GameStore.Models.UserGame", b =>
                {
                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GameStore.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
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
                    b.HasOne("GameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GameStore.Data.ApplicationUser")
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

                    b.HasOne("GameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
