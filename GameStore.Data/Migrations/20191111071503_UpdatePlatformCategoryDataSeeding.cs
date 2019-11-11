using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdatePlatformCategoryDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                column: "Name",
                value: "FPS");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4f8fad5b-d9cb-469f-a165-70867728950e"), "MMO" },
                    { new Guid("5f8fad5b-d9cb-469f-a165-70867728950e"), "Adventure" },
                    { new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"), "Puzzle" },
                    { new Guid("7f8fad5b-d9cb-469f-a165-70867728950e"), "Combat" },
                    { new Guid("8f8fad5b-d9cb-469f-a165-70867728950e"), "RPG" },
                    { new Guid("9f8fad5b-d9cb-469f-a165-70867728950e"), "Educational" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("432a91dd-d200-4c19-a767-f936cfbd8314"), "Playstation" },
                    { new Guid("532a91dd-d200-4c19-a767-f936cfbd8314"), "Xbox" },
                    { new Guid("632a91dd-d200-4c19-a767-f936cfbd8314"), "Nintendo" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash" },
                values: new object[] { "231edb2d-8c96-457c-b5e0-81a1164a12a3", new DateTime(2019, 11, 11, 7, 15, 2, 911, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEMAViK56KENS9pVWIYz7vTU9+I7qifTQOx3Vq+jrcDQwroZqDR64qHv3Wqsk2QC+6A==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5632106a-dc5c-41a8-bd51-2ac1ecaf9442", "AQAAAAEAACcQAAAAEP5LG2pvHiEqLdyhrSlaTF42tBwdZFdzCmLxszgO8u1bXiUSU4gsZqFz2zJngFHFsA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("6f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("7f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("8f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("9f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("432a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("532a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("632a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                column: "Name",
                value: "Action");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash" },
                values: new object[] { "a12cdaec-ea66-4bd6-9ce7-dba67c7ce965", new DateTime(2019, 11, 11, 5, 58, 42, 754, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHG1HuSUzNQb16bTORqyz5FQwWKvlSgv3oueYgRrrmHj3SCFSyMVwIBbkcPLBJUEwQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b865abe4-fb32-4e80-aae8-ec707d107271", "AQAAAAEAACcQAAAAEPjT2DDJqnBQGKJSSLAHSO1mM1iOtjHDFHbGCSq4EfLq+jPLY9h5V5NEEXsQWzAZiA==" });
        }
    }
}
