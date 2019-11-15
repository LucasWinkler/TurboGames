using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateReviewStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Review");

            migrationBuilder.AddColumn<int>(
                name: "ReviewStatus",
                table: "Review",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewStatus",
                table: "Review");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Review",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dd2f383-749d-4316-bfe3-74889fb5681b", new DateTime(2019, 11, 14, 14, 9, 35, 617, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEEqhlFAYQBF+pvsWn/A76U1zM1ZJdVTbP66ABa9uTp5jGuDjfOwT66ZZJzU/tsL/Iw==", "24c91950-2db0-41b4-8b67-891b2428d36f" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 14, 14, 9, 35, 620, DateTimeKind.Utc));
        }
    }
}
