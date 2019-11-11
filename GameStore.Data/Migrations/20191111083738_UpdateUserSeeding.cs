using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateUserSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", "231edb2d-8c96-457c-b5e0-81a1164a12a3" });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", "5632106a-dc5c-41a8-bd51-2ac1ecaf9442" });

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FavouriteCategoryId", "FavouritePlatformId", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldReceiveEmails", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", 0, "231edb2d-8c96-457c-b5e0-81a1164a12a3", new DateTime(2019, 11, 11, 7, 15, 2, 911, DateTimeKind.Utc), "admin@turbogames.com", true, null, null, "Turbo", 2, true, "Admin", false, null, "ADMIN@TURBOGAMES.COM", "ADMIN", "AQAAAAEAACcQAAAAEMAViK56KENS9pVWIYz7vTU9+I7qifTQOx3Vq+jrcDQwroZqDR64qHv3Wqsk2QC+6A==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), null, true, "1b1b111-111-11bb-111b-b11bb1b11bb1", false, false, "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FavouriteCategoryId", "FavouritePlatformId", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShouldReceiveEmails", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", 0, "5632106a-dc5c-41a8-bd51-2ac1ecaf9442", new DateTime(1999, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@turbogames.com", true, null, null, "Turbo", 1, false, "User", false, null, "USER@TURBOGAMES.COM", "USER", "AQAAAAEAACcQAAAAEP5LG2pvHiEqLdyhrSlaTF42tBwdZFdzCmLxszgO8u1bXiUSU4gsZqFz2zJngFHFsA==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), null, true, "2b2b222-222-22bb-222b-b22bb2b22bb2", false, false, "User" });
        }
    }
}
