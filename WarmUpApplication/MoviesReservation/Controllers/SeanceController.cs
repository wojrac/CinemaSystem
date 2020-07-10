using System.Diagnostics;
using System.Net.Http;
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
    public class SeanceController:ControllerBase
    {
        private readonly CinemaContext _context;

        public SeanceController(CinemaContext context)
        {
            _context = context;
        }

        //GET : api/seance/
        [HttpGet]
        public ActionResult<IEnumerable<Seance>> GetSeancesInToday([FromHeader] string date)
        {
            //trzeba sparsowac na date
            DateTime dateTime = DateTime.Parse(date);
           return  _context.Seances.Where(s=>s.StartOfSeance.Date == dateTime.Date).ToList();
        }
        //GET: api/seance/1
        [HttpGet("{id}")]
        public ActionResult<Seance> Get(long id, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin){
            var seanceUs = _context.Seances
            .Include(s=>s.Movie)
            .Include(s=>s.Seats)
            .Where(s=>s.SeanceId ==id).FirstOrDefault();  //tu jeszcze dojdzie include reservations i include seats
            return seanceUs;
            }
            var seance = _context.Seances
            .Include(s=>s.Movie)
            .Include(s=>s.Seats)
            .Include(s=>s.Reservations)
            .Where(s=>s.SeanceId ==id).FirstOrDefault();
            return seance;
        }
        //POST: api/seance
        [HttpPost]
        public ActionResult<Seance> AddSeance(Seance seance, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            var movie = _context.Movies.Where(movie=>movie.MovieId == seance.MovieId).FirstOrDefault();
            if(movie == null) return BadRequest(new { message = "This movie doesn't exist" });
            var seances  = _context.Seances.Where(s=>s.StartOfSeance.Day == seance.StartOfSeance.Day).ToList();   //seanse ktore odbywaja sie w tym samym dniu co wlasnie dodawany
            string status = SeanceLogic.IsAllValid(seances, seance, movie, seance.StartOfSeance, seance.EndOfSeance,movie.DurationInHours);
            if(!(status==""))
            return BadRequest( new {message =status});
             for(int i = 0 ; i<25 ; i++)
             {
                 Seat seat = new Seat
                 {
                     SeatNumber = i+1,
                     IsReserved = false,
                     Seance= seance
                 };
                 _context.Seats.Add(seat);
                 
             }
             //_context.Seances.Add(seance.Seats);
            _context.Seances.Add(seance);
            _context.SaveChanges();
            return seance;
        }
        //PUT api/seance/1
        [HttpPut("{id}")]
        public ActionResult<Seance> Update(Seance seance, long id, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            var oldSeance = _context.Seances.Where(s=>s.SeanceId == id).FirstOrDefault();
            if(oldSeance==null)
                return NotFound();
            var movie = _context.Movies.Where(movie=>movie.MovieId == seance.MovieId).FirstOrDefault();   //ten inny film
            var seances  = _context.Seances.Where(s=>s.StartOfSeance.Day == seance.StartOfSeance.Day && s.SeanceId != id).ToList();
            
            string status = SeanceLogic.IsAllValid(seances, seance, movie, seance.StartOfSeance, seance.EndOfSeance,movie.DurationInHours);
            if(!(status==""))
            return BadRequest( new {message =status});
             var newSeance = SeanceLogic.UpdateSeance(oldSeance,seance);
            _context.Entry(oldSeance).CurrentValues.SetValues(newSeance);
            _context.SaveChanges();
            return newSeance;
        }
        //DELETE api/seance/1
        [HttpDelete("{id}")]
        public ActionResult<Seance> Delete(long id, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            if(!user.IsAdmin) return Unauthorized();
            var seance = _context.Seances.Where(s=>s.SeanceId == id).FirstOrDefault();
            var reservations = _context.Reservations.Where(r=>r.Seance.SeanceId == id).ToList();
            //if(seance==null) return BadRequest(new {message="Seance doesnt exist"});
            _context.Seances.Remove(seance);
            _context.SaveChanges();
            return seance;
            
        }
    }   
}