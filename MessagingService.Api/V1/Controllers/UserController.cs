using System.Threading.Tasks;
using MessagingService.Api.Services;
using MessagingService.Api.V1.RequestModels;
using MessagingService.Api.V1.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Api.V1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserLoginRequestModel model)
        {
            var (isAuthenticated, user) = await _userService.AuthenticateUser(model.Username, model.Password);
            if (!isAuthenticated)
            {
                return Unauthorized();
            }
            var jwtToken = await _userService.GenerateJwtTokenForUser(user);
            return Ok(new JwtResponseModel(user, jwtToken));
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);
            if (user == null)
            {
                return BadRequest(new
                {
                    Message = $"Your username or email is in use.",
                    Code = 400001
                });
            }
            return Ok(new UserResponseModel(user.Username, user.Role));
        }
    }
}