using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        private readonly IMapper _mapper;
        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
            User user = _userService.Get(userId);
            if (user == null)
                return NotFound(new
                {
                    Success = false,
                    Message = $"No user found with user id: {userId}"
                }); 
          UserResDto response = _mapper.Map<UserResDto>(user);
            Console.Write("Email"+response.Email);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<int>> GetUserId()
        {
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            return Ok(userId);
        }
    }
}
