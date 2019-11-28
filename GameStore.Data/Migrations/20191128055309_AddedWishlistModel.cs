using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class AddedWishlistModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    AlreadyExists = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistGame",
                columns: table => new
                {
                    WishlistId = table.Column<Guid>(nullable: false),
                    GameId = table.Column<Guid>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistGame", x => new { x.WishlistId, x.GameId });
                    table.ForeignKey(
                        name: "FK_WishlistGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishlistGame_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistGame_GameId",
                table: "WishlistGame",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WishlistGame");

            migrationBuilder.DropTable(
                name: "Wishlist");

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
    }
}
