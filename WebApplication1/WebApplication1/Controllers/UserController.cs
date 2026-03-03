using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult<UserResDto>> Create(UserReqDto request)
        {
            User user=UserMapper.ToEntity(request);
             await _userService.Create(user);
            UserResDto response=UserMapper.ToResponse(user);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return CreatedAtAction(nameof(Get),new
            {
                userId=user.UserId,
            },response);
        }
        [HttpGet("{userId}")]
        public ActionResult<UserResDto> Get(int userId)
        {
            UserResDto response = UserMapper.ToResponse(_userService.Get(userId));
            if (response == null)
                return NotFound(new { 
                Success=false,
                Message=$"No user found with user id: {userId}"
                });
            return Ok(response);
        }
    }
}
