using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateReviewContentLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Review",
                maxLength: 1250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8000);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1af0b193-5e1e-420b-9722-b892c8df6c99", new DateTime(2019, 11, 16, 10, 21, 46, 794, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEKZ4RE7oCI0wBuG7XubRqvt/IIESOZ1oXhotX/lRtMRZhCdH3sUI4rjgQ4mIErCCcg==", "19a178a4-4023-48c1-a32a-9893e979bd4d" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 16, 10, 21, 46, 797, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Review",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1250);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d74641e-0906-40aa-b7e2-4e00e5dc67a2", new DateTime(2019, 11, 15, 3, 26, 13, 335, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHzA5EZsEyQ3/rhLcqdMHQLeROwxq9h68SgFYSX/ulzcaqxUYMTKMb6K0sNtOfRokw==", "42b9e5da-e0a9-420b-9c57-ce1e581bc9c7" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 15, 3, 26, 13, 338, DateTimeKind.Utc));
        }
    }
}
