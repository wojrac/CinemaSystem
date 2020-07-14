using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using MoviesReservation.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MoviesReservation.Logic
{
    public class ReservationLogic
    {
        public static List<int> ListOfReservedSeats(ICollection<Seat> seats, List<int> seatsTryingReserved)
        {
            var list = new List<int>();
            foreach(var reservedNumber in seatsTryingReserved)
            {
                foreach( var seat in seats)
                {
                    if(seat.SeatNumber == reservedNumber)
                    {
                        if(!seat.IsReserved)
                        {
                            seat.IsReserved = true;
                            list.Add(reservedNumber);
                        }
                    }
                }
            }
            return list;
        }
         public static void ListOfUnReservedSeats(ICollection<Seat> seats, List<int> seatsUnReserved)
        {
            foreach(var unReservedNumber in seatsUnReserved)
            {
                foreach( var seat in seats)
                {
                    if(seat.SeatNumber == unReservedNumber)
                    {
                        if(seat.IsReserved)
                        {
                            seat.IsReserved = false;
                        }
                    }
                }
            }
           // return seats;
        }
        public static void SendEmail(User user)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Cinema", "wojciech.rachwal@stazysta.comarch.com"));
            message.To.Add(new MailboxAddress(user.Name, user.Email));
            message.Subject= "Added Reservation";
            message.Body = new TextPart("plain"){
                Text = "You added reservation"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.stazysta.comarch.com", 587);
                client.Authenticate("wojciech.rachwal@stazysta.comarch.com", "***");
                client.Send(message);
                client.Disconnect(true);
            }


        }
        
        
    }
}