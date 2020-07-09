using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using MoviesReservation.Models;

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
        
        
    }
}