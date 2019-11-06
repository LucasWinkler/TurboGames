using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class AddEmailBoolForUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShouldReceiveEmails",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2120527b-2edb-498a-8f89-12f793439fc6", new DateTime(2019, 11, 6, 9, 3, 12, 268, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEAIuA2zZbWmkCNRUANdq2yLdBxv12sfFTXmkZc39AVNaKDUAqIBWNb2VOjTyUpO+HA==", "51b0680f-b398-4f52-ac0d-c37aac360b99" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cba1b373-bdbf-4a8a-a5b8-b5a1885955f4", new DateTime(2019, 11, 6, 9, 3, 12, 269, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEJHzzl2dtI0sAJVF/ZItBQdJE9Gk52j7KJ2H908xmAUJrneD9c0T26+9x8ETuCq6gg==", "9b729d30-4f45-4d30-8c1a-1a7b0a03c04c" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 9, 3, 12, 269, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 9, 3, 12, 269, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 9, 3, 12, 269, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShouldReceiveEmails",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be9db427-d717-48ca-9c54-42f5203ed475", new DateTime(2019, 11, 6, 8, 5, 44, 719, DateTimeKind.Utc), "AQAAAAEAACcQAAAAECZeptm1cSPY/DPTlgIDNsXV+9AI9iRgm6Y9WHqTqv+sZYjLbbccsPtkC/YxrbJ0lg==", "1cdcb387-f6bd-4ec3-8cfd-53ef865b496d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "162fe9c1-8346-40bd-a58f-1f5f077d8627", new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc), "AQAAAAEAACcQAAAAELkEDwt5DjoneU/znL3ywRM5McWqyFXffClii0sh9TJRdttSOKXaj+2Roh1/4fEVnw==", "d4a78888-af07-4d97-88b4-70f0ffe1b177" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));
        }
    }
}
