using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class AddBillingPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressID",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "User",
                newName: "AddressForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressID",
                table: "User",
                newName: "IX_User_AddressForeignKey");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Address",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressForeignKey",
                table: "User",
                column: "AddressForeignKey",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Address_AddressForeignKey",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AddressForeignKey",
                table: "User",
                newName: "AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_User_AddressForeignKey",
                table: "User",
                newName: "IX_User_AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Address_AddressID",
                table: "User",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
