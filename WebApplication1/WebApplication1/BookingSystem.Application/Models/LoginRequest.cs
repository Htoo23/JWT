using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Models
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
