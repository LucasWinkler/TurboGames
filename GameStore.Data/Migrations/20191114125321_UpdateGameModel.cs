using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStore.Data.Migrations
{
    public partial class UpdateGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "Game");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Game",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "TotalRating",
                table: "Game",
                nullable: false,
                defaultValue: 0);
        }
    }
}
