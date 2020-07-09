using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesReservation.Migrations
{
    public partial class OneToManySeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Seats_SeatsToReserveSeatId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SeatsToReserveSeatId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "SeatsToReserveSeatId",
                table: "Reservations");

            migrationBuilder.AddColumn<long>(
                name: "ReservationId",
                table: "Seats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_ReservationId",
                table: "Seats",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Reservations_ReservationId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_ReservationId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Seats");

            migrationBuilder.AddColumn<long>(
                name: "SeatsToReserveSeatId",
                table: "Reservations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatsToReserveSeatId",
                table: "Reservations",
                column: "SeatsToReserveSeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Seats_SeatsToReserveSeatId",
                table: "Reservations",
                column: "SeatsToReserveSeatId",
                principalTable: "Seats",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
