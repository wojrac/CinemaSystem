using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesReservation.Models;
using MoviesReservation.Logic;
using Microsoft.AspNetCore.Authorization;

namespace MoviesReservation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly CinemaContext _context;

        public MovieController(CinemaContext context)
        {
            _context = context;
        }
        //GET : api/movie
       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
           return await _context.Movies.ToListAsync();
        }*/
        //GET : api/movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
           return  _context.Movies.ToList();
        }
        //GET: api/movie/1
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(long id)
        {
            return _context.Movies.Where(m=>m.MovieId ==id).FirstOrDefault();
        }
        //POST api/movie
        [HttpPost]
        public ActionResult<Movie> Create(Movie movie, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }
        //PUT api/movie/1
        [HttpPut("{id}")]
        public ActionResult<Movie> Update(Movie movie, long id, [FromHeader] string  Authorization)  
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            MovieLogic movieLogic = new MovieLogic();
            var oldMovie = _context.Movies.Where(movie=>movie.MovieId == id).FirstOrDefault();
           // if(oldMovie ==null) return BadRequest(new {message="Movie doesnt exist"});
            var newMovie = movieLogic.UpdateMovie(oldMovie,movie);
            _context.Entry(oldMovie).CurrentValues.SetValues(newMovie);
            _context.SaveChanges();
            return newMovie;
            
            
        }
        //DELETE api/movie/1
        [HttpDelete("{id}")]
        public ActionResult<Movie> Delete(long id, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            var movie = _context.Movies.Where(m=>m.MovieId == id).FirstOrDefault();
           // if(movie==null) return BadRequest(new {message="Movie doesnt exist"});
             _context.Movies.Remove(movie);
             _context.SaveChanges();
             return movie;
            
        }

    }
}
