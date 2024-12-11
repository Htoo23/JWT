using BookingSystem.BookingSystem.Application.Interfaces;
using BookingSystem.BookingSystem.Application.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookingSystem.BookingSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;  

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        // Register a new user
        public async Task<AuthResult> RegisterAsync(RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new AuthResult { IsSuccess = false, ErrorMessage = "Registration failed." };
            }

            return new AuthResult { IsSuccess = true };
        }

        public async Task<AuthResult> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthResult { IsSuccess = false, ErrorMessage = "Invalid credentials." };
            }

            var token = await _tokenService.GenerateTokenAsync(user);
            return new AuthResult { IsSuccess = true, Token = token };
        }

        public async Task<UserProfile> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            return new UserProfile
            {
                Username = user.UserName,
                Email = user.Email,
                FullName = user.FullName,  
                PhoneNumber = user.PhoneNumber,
                DateJoined = user.DateJoined
            };
        }
    }
}
