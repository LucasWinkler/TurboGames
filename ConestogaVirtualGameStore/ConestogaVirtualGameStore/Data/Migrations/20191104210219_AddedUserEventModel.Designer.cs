﻿// <auto-generated />
using System;
using ConestogaVirtualGameStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191104210219_AddedUserEventModel")]
    partial class AddedUserEventModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConestogaVirtualGameStore.Data.ApplicationUser", b =>
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
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Address", b =>
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Category", b =>
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Event", b =>
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Friendship", b =>
                {
                    b.Property<string>("SenderId");

                    b.Property<string>("ReceiverId");

                    b.Property<bool>("IsFamily");

                    b.Property<int>("RequestStatus");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("Friendship");
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Developer")
                        .IsRequired();

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
                            Developer = "Game Developer 1",
                            Title = "Game Name 1",
                            TotalRating = 0
                        },
                        new
                        {
                            Id = new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Developer = "Game Developer 2",
                            Title = "Game Name 2",
                            TotalRating = 0
                        },
                        new
                        {
                            Id = new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CategoryId = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            Developer = "Game Developer 3",
                            Title = "Game Name 3",
                            TotalRating = 0
                        });
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Payment", b =>
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Review", b =>
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.UserEvent", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<Guid>("EventId");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("UserEvent");
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

            modelBuilder.Entity("ConestogaVirtualGameStore.Data.ApplicationUser", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("ConestogaVirtualGameStore.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Friendship", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Game", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.Review", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameId1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConestogaVirtualGameStore.Models.UserEvent", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser", "User")
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
                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser")
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

                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ConestogaVirtualGameStore.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
