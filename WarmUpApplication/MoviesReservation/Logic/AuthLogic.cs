using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace MoviesReservation.Logic
{
    public class AuthLogic
    {
        public static string ExtractUserEmailFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtEncodedString = token.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string

            var entoken = new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            var userMail = entoken.Claims.First(c=>c.Type == "unique_name").Value;
            return userMail;
        }
    }
}