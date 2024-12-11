using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Domain.Entities
{
    public class ClassSchedule : Controller
    {
         {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int RequiredCredits { get; set; }
        public int MaxSlots { get; set; }
        public DateTime StartTime { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
}
