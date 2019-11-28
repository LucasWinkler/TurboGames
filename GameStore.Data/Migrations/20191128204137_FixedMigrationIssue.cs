using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class FixedMigrationIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "User",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", "1af0b193-5e1e-420b-9722-b892c8df6c99" });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    AlreadyExists = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FavouriteCategoryId", "FavouritePlatformId", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "SecurityStamp", "ShouldReceiveEmails", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", 0, "1af0b193-5e1e-420b-9722-b892c8df6c99", new DateTime(2019, 11, 16, 10, 21, 46, 794, DateTimeKind.Utc), "user@turbogames.com", true, null, null, "Turbo", 2, "User", false, null, "USER@TURBOGAMES.COM", "USER", "AQAAAAEAACcQAAAAEKZ4RE7oCI0wBuG7XubRqvt/IIESOZ1oXhotX/lRtMRZhCdH3sUI4rjgQ4mIErCCcg==", new Guid("1c3e6619-7425-40de-944b-e07fc1f90ae7"), "19a178a4-4023-48c1-a32a-9893e979bd4d", false, false, "User" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 16, 10, 21, 46, 797, DateTimeKind.Utc) });
        }
    }
}
