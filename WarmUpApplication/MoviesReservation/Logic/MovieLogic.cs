using MoviesReservation.Models;


namespace MoviesReservation.Logic
{
    public class MovieLogic
    {
        public Movie UpdateMovie(Movie oldMovie, Movie newMovie)
        {
            oldMovie.Title = newMovie.Title;
            oldMovie.ImageFile = newMovie.ImageFile;
            oldMovie.DurationInHours = newMovie.DurationInHours;
            return oldMovie;
        }
        
    }
}