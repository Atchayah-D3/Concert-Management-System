using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.ServiceImpl;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public AuthController(IAuthService authService,IUserService userService,IJwtService jwtService)
        {
            _authService = authService;
            _userService = userService;
            _jwtService = jwtService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<LoginResDto>> Login(UserReqDto request)
        {
            User user = UserMapper.ToEntity(request);
            User loginUser = _authService.Login(user);
            if (loginUser!=null)
            {
                var token = await _jwtService
                    .GenerateToken(loginUser.UserId.ToString(),
                    loginUser.Email,
                    loginUser.Role);
                return Ok(new LoginResDto
                { 
                    UserId=loginUser.UserId,
                    Success =true,
                    Token = token,
                    LoginMessage="Login successfully"
                });
            }
            return Unauthorized(new LoginResDto{
                Success =false,
                Token=string.Empty,
                LoginMessage="Invalid Login credentials" });

        }
        [HttpPost("register")]
        public async Task<ActionResult<LoginResDto>> Register(UserReqDto request)
        {
            User user = UserMapper.ToEntity(request);
            User registeredUser = await _userService.Create(user);
            if (registeredUser != null)
            {
                var token = await _jwtService
                    .GenerateToken(registeredUser.UserId.ToString(),
                    registeredUser.Email,
                    registeredUser.Role);
                return Ok(new LoginResDto
                {
                    UserId=registeredUser.UserId,
                    Success = true,
                    Token = token,
                    LoginMessage = "Registered successfully"
                });
            }
            return BadRequest(new LoginResDto
            {
                Success = false,
                Token = string.Empty,
                LoginMessage = "Couldnot Register user"
            });
        }

    }
}