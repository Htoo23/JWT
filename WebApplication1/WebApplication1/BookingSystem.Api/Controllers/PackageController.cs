using BookingSystem.BookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

    }
}
