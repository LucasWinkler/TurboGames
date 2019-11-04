using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4c9e6679-7425-40de-944b-e07fc1f90ae7", 0, null, "3536ebe6-7ca5-4ac6-aeac-2992f83229d6", new DateTime(1998, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Admin First", 1, true, "Admin Last ", false, null, null, null, null, null, null, false, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[] { "4c9e6679-7425-40de-944b-e07fc1f90ae7", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 4, 22, 1, 14, 810, DateTimeKind.Utc).AddTicks(660) });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[] { "4c9e6679-7425-40de-944b-e07fc1f90ae7", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 4, 22, 1, 14, 810, DateTimeKind.Utc).AddTicks(1682) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "4c9e6679-7425-40de-944b-e07fc1f90ae7", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "4c9e6679-7425-40de-944b-e07fc1f90ae7", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "4c9e6679-7425-40de-944b-e07fc1f90ae7");
        }
    }
}
