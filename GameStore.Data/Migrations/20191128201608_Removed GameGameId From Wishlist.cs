using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class RemovedGameGameIdFromWishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Game_GameId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_GameId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Wishlist");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4f80cd7-0b03-450f-9961-5ef61bec2777", new DateTime(2019, 11, 28, 20, 16, 8, 210, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHB4+pJtILM7VmY5GR9ne734u07MH3sT0StuTbMFAEhzXbr2NpweBhEmvwR4IjTs3g==", "63f4ab7c-2480-4618-a847-7d56665c10e3" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 28, 20, 16, 8, 213, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameId",
                table: "Wishlist",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8185a30b-f033-431e-90b1-4b484ecab66a", new DateTime(2019, 11, 28, 5, 53, 8, 685, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEKlwdp2+VFZSSEEKnUbH1EX3Wlt0ExwL2lstjCgFzW1SG6JynBE1a2W6o7hr0O4BUQ==", "226699e5-318e-4121-b1d9-d64fdcd513a5" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 28, 5, 53, 8, 688, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_GameId",
                table: "Wishlist",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Game_GameId",
                table: "Wishlist",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
