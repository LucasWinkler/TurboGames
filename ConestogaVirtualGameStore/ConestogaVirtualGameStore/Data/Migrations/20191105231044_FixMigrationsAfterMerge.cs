using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class FixMigrationsAfterMerge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    Classification = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEvent",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvent", x => new { x.UserId, x.EventId });
                    table.ForeignKey(
                        name: "FK_UserEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserEvent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94cd35fe-6d8e-4ec9-8d83-d8ff58855993", new DateTime(2019, 11, 5, 23, 10, 43, 723, DateTimeKind.Utc).AddTicks(4470), "AQAAAAEAACcQAAAAEMo86Q8Ju3GIsckjCtA51JDfK8ACtlPX3zEe7TPd8NZVV/EGvFLTm6vy2+lMerXn5Q==", "69b81062-9f95-4d54-bcbe-50bcadcde928" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5a2e853-ff8c-4e75-81a9-6ee1c13e6cae", new DateTime(2019, 11, 5, 23, 10, 43, 724, DateTimeKind.Utc).AddTicks(9138), "AQAAAAEAACcQAAAAEF8xI6zr0C7mrSzMz5LeT5M9xJtJ0zChAt84OSRGecKMS4TOlzxlOAwEEuPk+BIUbw==", "8672ca4a-a818-4032-81c4-0b94662cd7b4" });

            migrationBuilder.InsertData(
                table: "UserGame",
                columns: new[] { "UserId", "GameId", "PurchaseDate" },
                values: new object[,]
                {
                    { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc).AddTicks(268) },
                    { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc).AddTicks(1204) },
                    { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 11, 5, 23, 10, 43, 725, DateTimeKind.Utc).AddTicks(1221) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEvent_EventId",
                table: "UserEvent",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEvent");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("1c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.DeleteData(
                table: "UserGame",
                keyColumns: new[] { "UserId", "GameId" },
                keyValues: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", new Guid("3c9e6679-7425-40de-944b-e07fc1f90ae7") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd2a9d4b-9313-4486-a7a0-a55f6eaf396e", new DateTime(2019, 11, 5, 5, 51, 29, 693, DateTimeKind.Utc).AddTicks(5874), "AQAAAAEAACcQAAAAEBd0aisB8frkpkvvlnysqV9MhnAFvrxWXWksM0WyZe6zm3jhFUiFvjPFxBxOf1bUhA==", "9a13e13d-3d0d-4425-a6fc-d0b6a90e95f6" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1243e38c-144a-40ab-b650-3fc217fe4a59", new DateTime(2019, 11, 5, 5, 51, 29, 695, DateTimeKind.Utc).AddTicks(448), "AQAAAAEAACcQAAAAEIxXdtJEXNV3tWPOo7FSEI+Lrwi72DGMdtzVZBBXAgtCRd+lbIekGGXQ6jLiF4oxyQ==", "a6b955a1-89ba-4642-9e41-a7186a645398" });
        }
    }
}
