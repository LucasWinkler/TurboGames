using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class SeperateBillingAddressFromShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "User",
                newName: "ShippingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressId",
                table: "User",
                newName: "IX_User_ShippingAddressId");

            migrationBuilder.AddColumn<Guid>(
                name: "BillingAddressId",
                table: "User",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "BillingAddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"), "da09b743-1566-444e-8089-63ee7a95f0d0", new DateTime(2019, 11, 10, 11, 24, 18, 382, DateTimeKind.Utc), "AQAAAAEAACcQAAAAENKymkkxOl0U53jptnFGUQxLR53XfBb82Xt8vKO55jFQlDYf26PdBo1WOv8RUVnQOw==", "e88aff1a-6f27-49a4-91c6-c0d2942f14d6" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "BillingAddressId", "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { new Guid("0c3e6619-7425-40de-944b-e07fc1f90ae7"), "857c906d-371f-4aab-a3b8-066c90ca032c", new DateTime(2019, 11, 10, 11, 24, 18, 385, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHqaLXyMgI6aUinUG7ij1bjI+6Mb0pNI+PHzD1fGxgpRntMj7cUCznInF2jsvvvDKw==", "b57b9994-8f7c-4d27-9973-26467482c12d" });

            migrationBuilder.CreateIndex(
                name: "IX_User_BillingAddressId",
                table: "User",
                column: "BillingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_BillingAddressId",
                table: "User",
                column: "BillingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_ShippingAddressId",
                table: "User",
                column: "ShippingAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_BillingAddressId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_ShippingAddressId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_BillingAddressId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "User",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_User_ShippingAddressId",
                table: "User",
                newName: "IX_User_AddressId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1a1a111-111-11aa-111a-a11aa1a11aa1",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f4611ee-f064-4109-9da2-9e44aae318cf", new DateTime(2019, 11, 7, 22, 30, 0, 445, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEJReIqhQaoTIFEab0ru3ruOXRZfJqHkcqMUvUsSCMql5sbCbYgfxlTXH5aBNfDyXFA==", "28815b6e-b447-4d8e-924d-6405d879237d" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2a2a222-222-22aa-222a-a22aa2a22aa2",
                columns: new[] { "ConcurrencyStamp", "DOB", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfb5cb4a-5500-42e7-a73f-9ff4cbadf6d3", new DateTime(2019, 11, 7, 22, 30, 0, 452, DateTimeKind.Utc), "AQAAAAEAACcQAAAAEHDjKnjquui/AkPpTMh4l8cZe8ZAaEwM/y5+usXVJnJoLiXKC6RqmX1q837SbYSVlw==", "9c003b05-c23b-48dc-8e0d-1f5ea1bda2e7" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressId",
                table: "User",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
