using System.Net;
using System.Collections;
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
using System.Diagnostics;


namespace MoviesReservation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController:ControllerBase
    {
        private readonly CinemaContext _context;

        public ReservationController(CinemaContext context)
        {
            _context = context;
        }
        //GET: api/reservation
        [HttpGet]
        public ActionResult<ICollection<Reservation>> GetAllReservationsOfUser([FromHeader] string  Authorization )
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var reservations = _context.Reservations.Where(r =>r.User.Email == userMail).ToList();
            return reservations;
        }
        [HttpGet("all")]
        //GET: api/reservation/all
        public ActionResult<ICollection<Reservation>> GetAllReservation([FromHeader] string Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            var reservations = _context.Reservations.ToList();
            if(!user.IsAdmin) return Unauthorized();
            return reservations;
        }
        //GET: api/reservation/1
        [HttpGet("{id}")]
        public ActionResult<Reservation> GetReservationDetailsById(long id, [FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var reservation = _context.Reservations
            .Include(r=>r.User)
            .Include(r=>r.Seance)
            .Where(r =>r.User.Email == userMail && r.ReservationId == id).FirstOrDefault();
            return reservation;
        }
        //POST api/reservation
        [HttpPost]
        public ActionResult<Reservation> AddReservation(Reservation reservation, [FromHeader] string Authorization)
        {
            var seats = _context.Seats.Where(seat=>seat.SeanceId == reservation.SeanceId).ToList();
            var reservedEffective = ReservationLogic.ListOfReservedSeats(seats, reservation.numberOfSeatsToReserve);
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            reservation.UserId = user.UserId;  //z tokena
            reservation.numberOfSeatsToReserve = reservedEffective;
            //ReservationLogic.SendEmail(user);
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }
        //DELETE api/reservation/1
        [HttpDelete("{id}")]
        public ActionResult<Reservation> Delete(long id)
        {
            var reservation = _context.Reservations.Where(r=>r.ReservationId == id).FirstOrDefault();
            var seats = _context.Seats.Where(seat=>seat.SeanceId == reservation.SeanceId).ToList();     
            ReservationLogic.ListOfUnReservedSeats(seats, reservation.numberOfSeatsToReserve);
           //reservation.numberOfSeatsToReserve = 
           _context.Reservations.Remove(reservation);
           _context.SaveChanges();
           return reservation;

        }
        

    }
}