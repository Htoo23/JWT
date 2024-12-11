using BookingSystem.BookingSystem.Application.Interfaces;
using BookingSystem.BookingSystem.Application.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookingSystem.BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Application.Models.RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            var result = await _userService.RegisterAsync(request);

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(new { Message = "Registration successful." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.Models.LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            var loginResult = await _userService.LoginAsync(request);

            if (!loginResult.IsSuccess)
            {
                return Unauthorized(loginResult.ErrorMessage);
            }

            return Ok(new { Token = loginResult.Token });
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userProfile = await _userService.GetProfileAsync();

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return Ok(userProfile);
        }
    }
}
