using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Infrastructure.Repositories
{
    public class ScheduleRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
