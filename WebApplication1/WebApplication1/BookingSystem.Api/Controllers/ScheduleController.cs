using BookingSystem.BookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.BookingSystem.Api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

    }

}
