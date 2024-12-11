using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Models
{
    public class UserProfileUpdateRequest
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
