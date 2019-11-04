using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class UpdatedUserAndGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Game",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                column: "Description",
                value: "The description");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                column: "Description",
                value: "The description");

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                column: "Description",
                value: "The description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Game");
        }
    }
}
