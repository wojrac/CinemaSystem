namespace MoviesReservation.Models
{
    public class UserWithToken:User
    {
        public string AccessToken {get; set;}

        public UserWithToken(User user)
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.IsAdmin = user.IsAdmin;
        }
    }
}