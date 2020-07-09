using System;
using System.Collections.Generic;
using MoviesReservation.Models;
using System.Diagnostics;

namespace MoviesReservation.Logic
{
    public class SeanceLogic
    {
        public static bool IsRoomValid(List<Seance> seances, DateTime start, DateTime end)
        {
            foreach(var item in seances)
            {          
                TimeSpan startEndSpan1 = start.Subtract(item.EndOfSeance);
                double diffSE1 = startEndSpan1.TotalHours;
                TimeSpan startEndSpan2 = item.StartOfSeance.Subtract(end);
                double diffSE2 = startEndSpan2.TotalHours;  
                  Debug.WriteLine("diffSe1:" + diffSE1);
                Debug.WriteLine("diffse2: " + diffSE2);       
//trzeba przekonwertowac Timespan na calkowita roznice
                if (!(diffSE1 > 0.25 || diffSE2 > 0.25)) 
                {                
                    return false;
                }          
            }
            return true;
        }
        public static bool IsTimeContainsInOpenHours(DateTime start, DateTime end)
        {
            DateTime openHour = new DateTime(start.Year, start.Month, start.Day, 8, 0,0);
            DateTime closeHour = new DateTime(end.Year, end.Month, end.Day, 23, 0,0);
            if(start.Subtract(openHour).TotalHours>0 && end.Subtract(closeHour).TotalHours <0) return true;
            return false;

        }
        public static bool IsSeanceIsInOneDay(DateTime start, DateTime end)
        {
            
            if(start.Date == end.Date) return true;
            return false;
        }
        public static bool IsMovieShorterThanSeance(DateTime start, DateTime end, double duration)
        {
            double seanceDuration = end.Subtract(start).TotalHours;
            Debug.WriteLine("DURATION MOVIE:" + duration);
            Debug.WriteLine("DURATION SEANS: " + seanceDuration);
            if(seanceDuration > duration) return true;
            return false;
        }
        public static string IsAllValid(List<Seance> seances, Seance seance, Movie movie,DateTime start, DateTime end, double duration)
        {
            if(!SeanceLogic.IsRoomValid(seances, seance.StartOfSeance, seance.EndOfSeance ) /*|| !SeanceLogic.IsTimeContainsInOpenHours(seance.StartOfSeance,seance.EndOfSeance)*/) 
             return  "Room is not epmty" ;
             if(!SeanceLogic.IsTimeContainsInOpenHours(seance.StartOfSeance,seance.EndOfSeance))
             return  "Cinema is close" ;
             if(!SeanceLogic.IsSeanceIsInOneDay(seance.StartOfSeance,seance.EndOfSeance))
             return "No one day" ;
             if(!SeanceLogic.IsMovieShorterThanSeance(seance.StartOfSeance,seance.EndOfSeance,movie.DurationInHours))
             return  "Movie is too long" ;
             return "";
        }
        public static Seance UpdateSeance(Seance oldSeance, Seance newSeance)
        {
            //oldSeance.Movie.MovieId = newSeance.Movie.MovieId;
            oldSeance.MovieId = newSeance.MovieId;
            oldSeance.Prize = newSeance.Prize;
            oldSeance.StartOfSeance = newSeance.StartOfSeance;
            oldSeance.EndOfSeance = newSeance.EndOfSeance;
            return oldSeance;
        }
    }
}