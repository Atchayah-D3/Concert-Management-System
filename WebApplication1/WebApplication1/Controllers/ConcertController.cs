using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Security.Claims;
using WebApplication1.Services.ServiceImpl;
using System.Reflection.Metadata.Ecma335;
using AutoMapper;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("[Controller]/")]
    [Produces("application/json")]    
    public class ConcertController : ControllerBase
    {
        private readonly IConcertService _concertService;
        private readonly OpaService _opaService;
        private readonly IUserService _userService;
        private readonly IHallBookingService _hallBookingService;
        private readonly IMapper _mapper;
        public ConcertController(IConcertService concertService,
            OpaService opaService,
            IUserService userService,
            IHallBookingService hallBookingService,
            IMapper mapper)
        {
            _concertService = concertService;
            _opaService = opaService;
            _userService = userService;
            _hallBookingService = hallBookingService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
       
        public async Task<ActionResult<ConcertResDto>> Create(ConcertReqDto concertDto)
        {
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            int userId = await _userService.GetUserId(UUID);
           var role = User.FindFirst(ClaimTypes.Role)?.Value;
           bool allowed = role != null ?
                await _opaService.IsAllowed(userId, role, "create_concert", "concert") : false;
           
            if (!allowed)
                return Forbid();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Concert concert = _mapper.Map<Concert>(concertDto);
            concert.CreatorId = userId;
            Concert savedConcert = _concertService.AddConcert(concert);
            if (savedConcert == null) {                 
                return BadRequest(); 
            }
            ConcertResDto response = _mapper.Map<ConcertResDto>(savedConcert);

            if (concertDto.HallBookingReq!=null)
            {
                if (concertDto.HallBookingReq.FromDateTime == null 
                    || concertDto.HallBookingReq.ToDateTime == null)
                    return BadRequest("Hall booking requires From and To datetime");
                HallBooking bookingReq = _mapper.Map<HallBooking>(concertDto.HallBookingReq);
                bookingReq.ConcertId = savedConcert.ConcertId;
               HallBooking booking=await _hallBookingService.ProcessBooking(concertDto.HallBookingReq.HallId, bookingReq);
                if (booking == null)
                    return BadRequest(new
                    {
                        Success = false,
                        Message = "Requested Hall is unavailable."
                    });
            }
            return CreatedAtAction(nameof(Get),
            new { Id = response.ConcertId },
            response);

        }
        [HttpGet("{id:min(1)}")]
        public ActionResult<ConcertResDto> Get(int id)
        {
            
           Concert concert=  _concertService.GetConcert(id);
            if (concert == null)
                return NotFound(new
                {
                    ConcertId = id,
                    message = $"No Concert found with the concert id {id}."
                });
            ConcertResDto response = _mapper.Map<ConcertResDto>(concert);
            return Ok(response);
        }
        [Authorize]
        [HttpGet("User")]
        public async Task<ActionResult<IEnumerable<ConcertResDto>>> GetUserConcerts()
        {
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int userId = await _userService.GetUserId(UUID);
            IEnumerable<Concert> concerts = _concertService.FetchUserConcert(userId);
            IEnumerable<ConcertResDto> response = _mapper.Map<IEnumerable<ConcertResDto>>(concerts);
            return Ok(response);
        }
        [HttpGet]
        public ActionResult<IEnumerable<ConcertResDto>> GetAll()
        {
            IEnumerable<Concert> concerts = _concertService.GetAllConcert();
            IEnumerable<ConcertResDto> response = _mapper.Map<IEnumerable<ConcertResDto>>(concerts);
            return Ok(response);
        }
        [Authorize]
        [HttpPut("{id:min(1)}")]
        public async Task<ActionResult<ConcertResDto>> Update([FromRoute] int id,[FromBody]ConcertReqDto request)
        {
            
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            Concert concert = _concertService.GetConcert(id);
            if (concert == null)
                return NotFound(new
                {
                    concertId = id,
                    message = "Requested Concert to update was not exists"
                });

            bool allowed = role != null ?
                await _opaService.IsAllowed(userId, role, "update_concert", "concert", new { owner = concert.CreatorId })
                : false;
            if (!allowed)
                return Forbid();

            Concert update = _mapper.Map<Concert>(request);
            _concertService.UpdateConcert(id, update);
            return NoContent();                   
        }
        [Authorize]
        [HttpDelete("{id:min(1)}")]
        public async Task<ActionResult> Delete(int id)
        {
            
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            Concert concert = _concertService.GetConcert(id);
            if(concert==null)
                return NotFound(new
                {
                    concertId = id,
                    message = "Requested Concert to delete was not exists"
                });

            bool allowed = role != null ? 
                await _opaService.IsAllowed(userId, role, "delete_concert", "concert",new {owner=concert.CreatorId}) 
                : false;            
            if (!allowed)
                return Forbid();

            _concertService.DeleteConcert(id);
            return  Ok(new
                {
                    concertId = id,
                    message = "Concert removed successfully"
                });
                
        }
    }
}