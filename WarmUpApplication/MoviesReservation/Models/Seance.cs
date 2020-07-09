using System.Collections;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesReservation.Models
{
    public class Seance
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SeanceId {get;set;}
        public virtual ICollection<Reservation> Reservations {get;set;}
        public long MovieId {get;set;}
        public virtual Movie Movie {get;set;}

        public DateTime StartOfSeance{get;set;}
        public DateTime EndOfSeance{get;set;}
        public int Prize {get;set;}
        public virtual ICollection<Seat> Seats {get;set;}
        

    }
}