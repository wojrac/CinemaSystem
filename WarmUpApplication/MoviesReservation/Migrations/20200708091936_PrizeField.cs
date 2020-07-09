using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesReservation.Migrations
{
    public partial class PrizeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prize",
                table: "Seances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prize",
                table: "Seances");
        }
    }
}
