using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoviesReservation.Models
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ReservationId {get; set;}
        public long UserId{get;set;}
        public virtual User User {get;set;}
        public long SeanceId {get;set;}
        public virtual Seance Seance {get;set;}
        public virtual List<int> numberOfSeatsToReserve {get;set;}

    }
}