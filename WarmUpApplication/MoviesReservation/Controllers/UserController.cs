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
using System.Diagnostics;

namespace MoviesReservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly CinemaContext _context;
        private readonly JWTSettings _jwtsettings;

        public UserController(CinemaContext context, IOptions<JWTSettings> jwtsettings)
        {
            _context = context;
            _jwtsettings = jwtsettings.Value;
        }
        [HttpGet]
        public void Index()
        {

        }
        //GET : api/user
        /*[HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
           return  _context.Users.ToList();
        }*/
        //GET: api/user/1
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            return _context.Users.Where(us=>us.UserId == id).FirstOrDefault();
        }
        //GET: api/user
       /* [HttpGet("GetUser")]
        public ActionResult<User> GetUser()
        {
            string emailAddress = HttpContext.User.Identity.Name;
            var user = _context.Users.Where(user=>user.Email == emailAddress).FirstOrDefault();
            user.Password = null;
        }*/
        //GET api/user/Login
        [HttpGet("Login")] 
        public ActionResult<UserWithToken> Login([FromBody] User user)
        {
            user = _context.Users.Where(u=>u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if(user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
                //return NotFound();
            }
            UserWithToken userWithToken = new UserWithToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userWithToken.AccessToken = tokenHandler.WriteToken(token);


            return userWithToken;
        }
        //GET: api/user/logout
       /* [HttpGet("Logout")]
        public ActionResult<UserWithToken> Logout()
        {
            
        }*/
        //POST api/user/Register
        [HttpPost("Register")]
        public void Register([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

    }
}