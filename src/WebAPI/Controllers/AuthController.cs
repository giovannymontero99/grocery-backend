using BCrypt.Net;
using GroceryBackend.src.Application.DTO;
using GroceryBackend.src.Application.Interfaces;
using GroceryBackend.src.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryBackend.src.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth/")]
    public class AuthController : ControllerBase
    {
        // Services
        readonly private IAuthService _authService;
        readonly private IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] LoginRequest request) 
        {
            try
            {
                var user = await _userService.GetUserByName(request.Name);
                if (user != null) return Conflict(new { Message = "User already exist" });

                // Transform the request in a valid user dto
                UserDto userDto = new UserDto()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                    FullName = request.FullName,
                };

                await _userService.CreateUserAsync(userDto);
                return Ok();
            }
            catch (Exception e) {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                // Get the user by name
                var user = await _userService.GetUserByName(request.Name);

                // If user doesn't exist, return unauthorized
                if (user == null) return NotFound(new { Message = "User does not exist" });

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) return Unauthorized();


                // Create a new token by Id and Email
                var token = _authService.GenerateJwtToken(user.Id.ToString(), user.Email, "User");
                return Ok(new { Token = token });
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }
    }
}

public class LoginRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}
