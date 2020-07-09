/*using System.Security.Claims;
using System.Text;
using System;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MoviesReservation.Models;
using System.Linq;

namespace MoviesReservation.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly CinemaContext _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
         ILoggerFactory logger, UrlEncoder encoder , ISystemClock clock, CinemaContext context ):base(options,logger,encoder,clock)
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization Header was not found");

            try{
                
            var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
            string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
            string emailAddress = credentials[0];
            string password = credentials[1];

            User user = _context.Users.Where(user=>user.Email == emailAddress && user.Password == password).FirstOrDefault();

            if(user == null)
            {
                AuthenticateResult.Fail("Invalid username or password"); 
            }
            else
            {
                var claims = new [] { new Claim(ClaimTypes.Name, user.Email) };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket  =  new AuthenticationTicket(principal,Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }

            }catch(Exception)
            {
                return AuthenticateResult.Fail("Error");    
            }
            return AuthenticateResult.Fail("Fail");

        }
    }
}*/