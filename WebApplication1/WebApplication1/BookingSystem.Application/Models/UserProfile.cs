using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateJoined { get; set; }
    }
}