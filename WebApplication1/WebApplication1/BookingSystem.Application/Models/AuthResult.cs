using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}
