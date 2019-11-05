using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class DataSeededAdminAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "FirstName", "Gender", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a1a111-111-11aa-111a-a11aa1a11aa1", 0, null, "fe55d129-4f8d-4b89-8a04-09da93e48f5d", new DateTime(2019, 11, 5, 4, 48, 51, 325, DateTimeKind.Utc).AddTicks(8397), "admin@gmail.com", true, "Turbo", 2, true, "Games", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDCyvSGcoq6eqtWdkDz9Cf/cwtgjVVajRHB4MK7GQdqD2Tpu7R7dEtY5D+MXWFwxfw==", null, null, true, "5e3efb35-8356-4e0e-8ee0-d1ef533d4125", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1");
        }
    }
}
