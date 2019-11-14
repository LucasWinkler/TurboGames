using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateReviewRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "Review",
                nullable: false,
                oldClrType: typeof(int));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Review",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52c18fda-a95d-4c8d-828c-d66a4e57e2e3", new DateTime(2019, 11, 14, 13, 53, 3, 713, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEPalMKdp/GK8TtqRw1L0ktnyoGTz4weo9hpE8ZxP56JuB40qH50XcUzAFI1MJ+B3kA==", "5b8ea500-72b3-4ecd-904b-a94a28143303" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 14, 13, 53, 3, 716, DateTimeKind.Utc));
        }
    }
}
