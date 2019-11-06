using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acb61671-a7c7-4a60-a953-e6db0c68e17a", new DateTime(2019, 11, 6, 0, 49, 43, 218, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEP/sauskns2IdhwTq8lqJR9S4GOuA9/U0aqsk1GEKVxOEm4Taa8WzWCtsXYLMbRq6Q==", "8ffd08fc-df73-41b9-8dac-2e2222f500e5" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcf8ac15-79d7-4c53-97a7-5ba513e96bc2", new DateTime(2019, 11, 6, 0, 49, 43, 220, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEOdYcvUQSJ9+3a58+e1epGIP5g93TzdJKtDpZ79ItAFuEKfh6YSzkd3f4PCvHeYxVA==", "9c31c47f-f4fe-4645-82b0-5c5c7ff37420" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 0, 49, 43, 220, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 0, 49, 43, 220, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 0, 49, 43, 220, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94cd35fe-6d8e-4ec9-8d83-d8ff58855993", new DateTime(2019, 11, 5, 23, 10, 43, 723, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEMo86Q8Ju3GIsckjCtA51JDfK8ACtlPX3zEe7TPd8NZVV/EGvFLTm6vy2+lMerXn5Q==", "69b81062-9f95-4d54-bcbe-50bcadcde928" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5a2e853-ff8c-4e75-81a9-6ee1c13e6cae", new DateTime(2019, 11, 5, 23, 10, 43, 724, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEF8xI6zr0C7mrSzMz5LeT5M9xJtJ0zChAt84OSRGecKMS4TOlzxlOAwEEuPk+BIUbw==", "8672ca4a-a818-4032-81c4-0b94662cd7b4" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc));
        }
    }
}
