using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesReservation.Migrations
{
    public partial class changeTypeDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Movies");

            migrationBuilder.AddColumn<double>(
                name: "DurationInHours",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInHours",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
