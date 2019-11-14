using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UserGameSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FavouriteCategoryId", "FavouritePlatformId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "SecurityStamp", "ShouldReceiveEmails", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", 0, "52c18fda-a95d-4c8d-828c-d66a4e57e2e3", new DateTime(2019, 11, 14, 13, 53, 3, 713, DateTimeKind.Utc), "user@turbogames.com", true, null, null, "Turbo", 2, "User", false, null, "USER@TURBOGAMES.COM", "USER", "AQAAAAEAACcQAAAAEPalMKdp/GK8TtqRw1L0ktnyoGTz4weo9hpE8ZxP56JuB40qH50XcUzAFI1MJ+B3kA==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "5b8ea500-72b3-4ecd-904b-a94a28143303", false, false, "User" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 14, 13, 53, 3, 716, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", "52c18fda-a95d-4c8d-828c-d66a4e57e2e3" });
        }
    }
}
