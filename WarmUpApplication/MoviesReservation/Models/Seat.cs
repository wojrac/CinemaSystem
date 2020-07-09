using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesReservation.Models
{
    public class Seat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SeatId {get;set;}
        public int SeatNumber{get;set;}
        public bool IsReserved {get;set;}
        public long SeanceId {get;set;}
        public virtual Seance Seance {get;set;}
        
    }
}