using Microsoft.EntityFrameworkCore.Migrations;

namespace ConestogaVirtualGameStore.Data.Migrations
{
    public partial class UpdatedEventClassification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                table: "Event",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Classification",
                table: "Event",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
