using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class AddedAdminAndStandardUserDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", 0, null, "dd2a9d4b-9313-4486-a7a0-a55f6eaf396e", new DateTime(2019, 11, 5, 5, 51, 29, 693, DateTimeKind.Utc).AddTicks(5874), "admin@gmail.com", true, "Turbo", 2, true, "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEBd0aisB8frkpkvvlnysqV9MhnAFvrxWXWksM0WyZe6zm3jhFUiFvjPFxBxOf1bUhA==", null, null, true, "9a13e13d-3d0d-4425-a6fc-d0b6a90e95f6", false, "Admin" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2a2a222-222-22aa-222a-a22aa2a22aa2", 0, null, "1243e38c-144a-40ab-b650-3fc217fe4a59", new DateTime(2019, 11, 5, 5, 51, 29, 695, DateTimeKind.Utc).AddTicks(448), "standard.user@gmail.com", true, "Turbo", 2, false, "User", false, null, "STANDARD.USER@GMAIL.COM", "USER", "AQAAAAEAACcQAAAAEIxXdtJEXNV3tWPOo7FSEI+Lrwi72DGMdtzVZBBXAgtCRd+lbIekGGXQ6jLiF4oxyQ==", null, null, true, "a6b955a1-89ba-4642-9e41-a7186a645398", false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2");
        }
    }
}
