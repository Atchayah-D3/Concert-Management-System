using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]/")]
    public class HallController : ControllerBase
    {
        private readonly IHallService _hallService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HallController(IHallService hallService,
            IUserService userService,
            IMapper mapper)
        {
            _hallService = hallService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<HallDto>> AddHall(HallDto request)
        {
            Hall hall = _mapper.Map<Hall>(request);
            string uuid= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int ownerId = await _userService.GetUserId(uuid);
            hall.hallOwnerId = ownerId;
            await _hallService.AddHall(hall);
            return CreatedAtAction(nameof(Get),
                new { Id=hall.HallId},
                request);
        }
        [HttpGet]
        public async Task<ActionResult<List<HallDto>>> Get()
        {
            List<Hall> halls = _hallService.GetAll();
            List<HallDto> response = _mapper.Map<List<HallDto>>(halls);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HallDto>> GetById(int id)
        {
            Hall hall = _hallService.GetHall(id);
            if (hall == null)
                return BadRequest("Hall Not Found");
            HallDto response = _mapper.Map<HallDto>(hall);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HallDto>> Update(int id,HallDto reqHall)
        {
            Hall oldHall = _hallService.GetHall(id);
            Hall updatedHall = _mapper.Map<Hall>(reqHall);
            if (oldHall == null)
                return BadRequest("Hall not found");
            updatedHall.hallOwnerId = oldHall.hallOwnerId;
            _hallService.UpdateHall(id,updatedHall);
            
            return Ok(reqHall);
        }
        
    }
}
