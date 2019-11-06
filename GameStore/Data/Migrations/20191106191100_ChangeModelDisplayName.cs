using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class ChangeModelDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d849434-2cc4-4511-a46c-32e7e29e90fb", new DateTime(2019, 11, 6, 19, 10, 59, 878, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEMzrtX4YRevQ6MdIBuMh1LfVYBvwxBs5xMJ2uJwsBDxrPSBc0OHZNZdV3m2kxWBfoA==", "babff118-d376-4d08-b2ea-6fefbe5250fb" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a0c58f8-fa44-4a88-a446-d3f39dff4e00", new DateTime(2019, 11, 6, 19, 10, 59, 880, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEKCyupGTWRVSzZFw/FUjf/iFVwaUZcoqkhS7d7ErrCrYt7dtmeO0JiAwGKKoyjU0Wg==", "9cdd021e-8abe-4830-913a-6de73fca432a" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 19, 10, 59, 880, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 19, 10, 59, 880, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 19, 10, 59, 880, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
