using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdatePlatformAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteCategoryId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FavouritePlatformId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlatformId",
                table: "Game",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                column: "Name",
                value: "Action");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f8fad5b-d9cb-469f-a165-70867728950e"), "Adventure" },
                    { new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), "Strategy" },
                    { new Guid("3f8fad5b-d9cb-469f-a165-70867728950e"), "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), "Steam" },
                    { new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"), "Origin" },
                    { new Guid("332a91dd-d200-4c19-a767-f936cfbd8314"), "Blizzard" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be9db427-d717-48ca-9c54-42f5203ed475", new DateTime(2019, 11, 6, 8, 5, 44, 719, DateTimeKind.Utc), "AQAAAAEAACcQAAAAECZeptm1cSPY/DPTlgIDNsXV+9AI9iRgm6Y9WHqTqv+sZYjLbbccsPtkC/YxrbJ0lg==", "1cdcb387-f6bd-4ec3-8cfd-53ef865b496d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "162fe9c1-8346-40bd-a58f-1f5f077d8627", new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc), "AQAAAAEAACcQAAAAELkEDwt5DjoneU/znL3ywRM5McWqyFXffClii0sh9TJRdttSOKXaj+2Roh1/4fEVnw==", "d4a78888-af07-4d97-88b4-70f0ffe1b177" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 8, 5, 44, 721, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "Description", "Developer", "PlatformId", "Title" },
                values: new object[] { "Counter-Strike: Global Offensive (CS:GO) is a multiplayer first-person shooter video game developed by Hidden Path Entertainment and Valve Corporation. It is the fourth game in the Counter-Strike series and was released for Microsoft Windows, OS X, Xbox 360, and PlayStation 3 on August 21, 2012, while the Linux version was released in 2014.", "Valve", new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), "Counter-Strike: Global Offensive" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "Description", "Developer", "PlatformId", "Price", "Title" },
                values: new object[] { "Apex Legends is a free-to-play Battle Royale game where legendary competitors battle for glory, fame, and fortune on the fringes of the Frontier.", "Respawn", new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"), 0.0, "Apex Legends" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CategoryId", "Description", "Developer", "PlatformId", "Price", "Title" },
                values: new object[] { new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"), "Age of Empires II: The Age of Kings is a real-time strategy video game developed by Ensemble Studios and published by Microsoft. Released in 1999 for Microsoft Windows and Macintosh, it is the second game in the Age of Empires series.", "Forgotten Empires, Tantalus Media, Wicked Witch", new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"), 21.99, "Age of Empires II: Definitive Edition" });

            migrationBuilder.CreateIndex(
                name: "IX_User_FavouriteCategoryId",
                table: "User",
                column: "FavouriteCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FavouritePlatformId",
                table: "User",
                column: "FavouritePlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlatformId",
                table: "Game",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Platform_PlatformId",
                table: "Game",
                column: "PlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Category_FavouriteCategoryId",
                table: "User",
                column: "FavouriteCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Platform_FavouritePlatformId",
                table: "User",
                column: "FavouritePlatformId",
                principalTable: "Platform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Platform_PlatformId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Category_FavouriteCategoryId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Platform_FavouritePlatformId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FavouriteCategoryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FavouritePlatformId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlatformId",
                table: "Game");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3f8fad5b-d9cb-469f-a165-70867728950e"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("132a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("232a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.DeleteData(
                table: "Platform",
                keyColumn: "Id",
                keyValue: new Guid("332a91dd-d200-4c19-a767-f936cfbd8314"));

            migrationBuilder.DropColumn(
                name: "FavouriteCategoryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FavouritePlatformId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Game");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Category Description", "Category Name" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "Description", "Developer", "Title" },
                values: new object[] { "The description", "Game Developer 1", "Game Name 1" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("2c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "Description", "Developer", "Price", "Title" },
                values: new object[] { "The description", "Game Developer 2", 54.99, "Game Name 2" });

            migrationBuilder.UpdateData(
                table: "Game",
                keyColumn: "Id",
                keyValue: new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "CategoryId", "Description", "Developer", "Price", "Title" },
                values: new object[] { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), "The description", "Game Developer 3", 19.99, "Game Name 3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "249602f7-04c0-4be2-aec0-402ddadecc54", new DateTime(2019, 11, 6, 4, 50, 13, 596, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEJ6yKfFX6c0F5tcz3/cCYWSI5i6Uz8yOtGHLFfT6ZZ0FBqcEiAYJI6W8ZIPBqIMnSQ==", "ab5ca0ce-f0db-499a-8489-41a17c293a58" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b319c93e-722f-42dc-bb8d-91d057638cc0", new DateTime(2019, 11, 6, 4, 50, 13, 597, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEJI7ke+RwPooxGee3wooL2rel5dIK7+cWgxxJ6HfDsNIhXRPDDvyPRKMrrzYhoOUXw==", "da820853-cad8-43e7-8a9a-7edca1194a45" });

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 4, 50, 13, 597, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 4, 50, 13, 597, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") },
                column: "PurchaseDate",
                value: new DateTime(2019, 11, 6, 4, 50, 13, 597, DateTimeKind.Utc));
        }
    }
}
