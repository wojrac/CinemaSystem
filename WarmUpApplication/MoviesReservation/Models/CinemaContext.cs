using Microsoft.EntityFrameworkCore;


namespace MoviesReservation.Models
{
    public class CinemaContext:DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options):base(options) {  }

        public DbSet<User> Users {get;set;}
        public DbSet<Reservation> Reservations {get;set;}
        public DbSet<Seance> Seances {get;set;}
        public DbSet<Movie> Movies {get;set;}
        public DbSet<Seat> Seats{get;set;}
    }
}