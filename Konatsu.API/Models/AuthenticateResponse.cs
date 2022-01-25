using Konatsu.API.Entities;
using System;

namespace Konatsu.API.Models
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(UserEntity user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            About = user.About;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}
