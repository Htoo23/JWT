using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Interfaces
{
    public class IUserService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
