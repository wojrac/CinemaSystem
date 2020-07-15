using System.Net;
using System;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MoviesReservation.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using MoviesReservation.Logic;
using System.Diagnostics;


namespace MoviesReservation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController:ControllerBase
    {
        
          private readonly CinemaContext _context;
       

        public UserProfileController(CinemaContext context)
        {
            _context = context;

        }
        //GET : api/userProfile
        [HttpGet]
        public ActionResult<User> GetUserDetails([FromHeader] string  Authorization)
        {
            var userMail = AuthLogic.ExtractUserEmailFromToken(Authorization);
            var user = _context.Users.Where(u=>u.Email == userMail).FirstOrDefault();
            return user;
        }

    }
}