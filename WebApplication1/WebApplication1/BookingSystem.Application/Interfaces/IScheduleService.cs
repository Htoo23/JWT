using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Interfaces
{
    public class IScheduleService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
