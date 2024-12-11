using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Domain.Entities
{
    public class Booking : Controller
    {
          
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ClassScheduleId { get; set; }
        public ClassSchedule ClassSchedule { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
