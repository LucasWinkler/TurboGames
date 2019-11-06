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
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191105055129_AddedAdminAndStandardUserDataSeeding")]
    partial class AddedAdminAndStandardUserDataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
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

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PaymentId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = "1a1a111-111-11aa-111a-a11aa1a11aa1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dd2a9d4b-9313-4486-a7a0-a55f6eaf396e",
                            DOB = new DateTime(2019, 11, 5, 5, 51, 29, 693, DateTimeKind.Utc).AddTicks(5874),
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Turbo",
                            Gender = 2,
                            IsAdmin = true,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEBd0aisB8frkpkvvlnysqV9MhnAFvrxWXWksM0WyZe6zm3jhFUiFvjPFxBxOf1bUhA==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "9a13e13d-3d0d-4425-a6fc-d0b6a90e95f6",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "2a2a222-222-22aa-222a-a22aa2a22aa2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1243e38c-144a-40ab-b650-3fc217fe4a59",
                            DOB = new DateTime(2019, 11, 5, 5, 51, 29, 695, DateTimeKind.Utc).AddTicks(448),
                            Email = "standard.user@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Turbo",
                            Gender = 2,
                            IsAdmin = false,
                            LastName = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "STANDARD.USER@GMAIL.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEIxXdtJEXNV3tWPOo7FSEI+Lrwi72DGMdtzVZBBXAgtCRd+lbIekGGXQ6jLiF4oxyQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "a6b955a1-89ba-4642-9e41-a7186a645398",
                            TwoFactorEnabled = false,
                            UserName = "User"
                        });
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

            modelBuilder.Entity("GameStore.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Description = "Category Description",
                            Name = "Category Name"
                        });
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

                    b.Property<double?>("Price");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TotalRating");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Game");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Description = "The description",
                            Developer = "Game Developer 1",
                            Title = "Game Name 1",
                            TotalRating = 0
                        },
                        new
                        {
                            Id = new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Description = "The description",
                            Developer = "Game Developer 2",
                            Title = "Game Name 2",
                            TotalRating = 0
                        },
                        new
                        {
                            Id = new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Description = "The description",
                            Developer = "Game Developer 3",
                            Title = "Game Name 3",
                            TotalRating = 0
                        });
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
                });

            modelBuilder.Entity("GameStore.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Created");

                    b.Property<string>("GameId")
                        .IsRequired();

                    b.Property<Guid>("GameId1");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GameId1");

                    b.HasIndex("ReviewerId");

                    b.ToTable("Review");
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
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

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

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("GameStore.Data.ApplicationUser", b =>
                {
                    b.HasOne("GameStore.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("GameStore.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
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
                });

            modelBuilder.Entity("GameStore.Models.Review", b =>
                {
                    b.HasOne("GameStore.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameStore.Data.ApplicationUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
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