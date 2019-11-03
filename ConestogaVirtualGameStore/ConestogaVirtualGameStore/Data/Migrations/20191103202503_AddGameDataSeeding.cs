using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class AddGameDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Category Description", "Category Name" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CategoryId", "Developer", "Title", "TotalRating" },
                values: new object[] { new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Game Developer 1", "Game Name 1", 0 });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CategoryId", "Developer", "Title", "TotalRating" },
                values: new object[] { new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Game Developer 2", "Game Name 2", 0 });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "CategoryId", "Developer", "Title", "TotalRating" },
                values: new object[] { new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "Game Developer 3", "Game Name 3", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));
        }
    }
}
