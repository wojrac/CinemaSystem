using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MoviesReservation.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long MovieId{get;set;}
        public string Title {get;set;}
        public double DurationInHours {get;set;}
        public string ImageFile {get;set;}
    }
}