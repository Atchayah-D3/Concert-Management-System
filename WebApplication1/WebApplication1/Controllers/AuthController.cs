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
        [HttpPost]
        public ActionResult<LoginResDto> Login(UserReqDto request)
        {
            User user = UserMapper.ToEntity(request);
            User loginUser = _authService.Login(user);
            if (loginUser!=null)
            {
                var token = _jwtService
                    .GenerateToken(loginUser.UserId.ToString(),
                    loginUser.Email,
                    loginUser.Role);
                return Ok(new LoginResDto
                {
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

    }
}