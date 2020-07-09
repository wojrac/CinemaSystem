using System.IO.Enumeration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesReservation.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId {get;set;}
        //[Required(ErrorMessage = "Musisz podac imie")]
        public string Name {get;set;}
        //[Required(ErrorMessage = "Musisz podac nazwisko")]
        public string LastName {get;set;}
        //[Required(ErrorMessage = "Musisz podac mejl")]
        public string Email {get;set;}
        //[Required(ErrorMessage = "Musisz podac haslo")]
        //[StringLength(40, ErrorMessage = "Haslo", MinimumLength = 8)]
        public bool IsAdmin {get;set;}
        public string Password {get;set;}
        [NotMapped]
        //[Required(ErrorMessage = "Musisz potwierdzic haslo")]
        //[Compare("Password")]
        public string ConfirmedPassword {get;set;}
    }
}