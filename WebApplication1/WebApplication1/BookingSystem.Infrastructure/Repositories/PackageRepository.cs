using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Infrastructure.Repositories
{
    public class PackageRepository : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
