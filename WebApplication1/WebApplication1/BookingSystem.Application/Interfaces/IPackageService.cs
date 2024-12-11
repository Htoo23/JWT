using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Application.Interfaces
{
    public class IPackageService : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
