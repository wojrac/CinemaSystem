using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesReservation.Migrations
{
    public partial class SeanceIdInSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats");

            migrationBuilder.AlterColumn<long>(
                name: "SeanceId",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "SeanceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats");

            migrationBuilder.AlterColumn<long>(
                name: "SeanceId",
                table: "Seats",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "SeanceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
