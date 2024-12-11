using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
