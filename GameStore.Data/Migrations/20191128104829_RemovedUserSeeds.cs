using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class RemovedUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", "1af0b193-5e1e-420b-9722-b892c8df6c99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FavouriteCategoryId", "FavouritePlatformId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "SecurityStamp", "ShouldReceiveEmails", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", 0, "1af0b193-5e1e-420b-9722-b892c8df6c99", new DateTime(2019, 11, 16, 10, 21, 46, 794, DateTimeKind.Utc), "user@turbogames.com", true, null, null, "Turbo", 2, "User", false, null, "USER@TURBOGAMES.COM", "USER", "AQAAAAEAACcQAAAAEKZ4RE7oCI0wBuG7XubRqvt/IIESOZ1oXhotX/lRtMRZhCdH3sUI4rjgQ4mIErCCcg==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "19a178a4-4023-48c1-a32a-9893e979bd4d", false, false, "User" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 16, 10, 21, 46, 797, DateTimeKind.Utc) });
        }
    }
}
