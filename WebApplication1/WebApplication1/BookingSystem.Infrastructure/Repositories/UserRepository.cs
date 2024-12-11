using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Infrastructure.Repositories
{
    public class UserRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
