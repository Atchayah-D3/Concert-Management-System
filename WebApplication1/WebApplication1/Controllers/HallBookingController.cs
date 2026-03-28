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
    public class HallBookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHallBookingService _hallBookingService;
        private readonly IUserService _userService;
        public HallBookingController(IMapper mapper,
            IHallBookingService hallBookingService,
            IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
            _hallBookingService = hallBookingService;
        }
        [HttpPost("{hallId}")]
        public async Task<ActionResult<HallBookingDto>> BookHall(int hallId, HallBookingDto request)
        {
            string uuid = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(uuid);
            HallBooking bookingReq = _mapper.Map<HallBooking>(request);
            bookingReq.UserId = userId;
            HallBooking booking = await _hallBookingService.ProcessBooking(hallId, bookingReq);
            
            if (booking == null)
                return BadRequest(new
                {
                    Success = false,
                    Message = "Requested Hall is unavailable."
                });
            HallBookingDto response = _mapper.Map<HallBookingDto>(booking);
            return CreatedAtAction(nameof(GetBookings), 
                new {
                hallId=booking.HallId
                },
                response);
        }
        [HttpGet("hall/{hallId}")]
        public ActionResult<HallBookingDto> GetBookings(int hallId)
        {
            List<HallBooking> hallBookings= _hallBookingService.GetHallBookings(hallId);
            List<HallBookingDto> response = _mapper.Map<List<HallBookingDto>>(hallBookings);
            return Ok(response);
        }
        [HttpDelete("{bookingId}")]
        public ActionResult<HallBookingDto> CancelBooking(int bookingId)
        {
            bool isDeleted = _hallBookingService.ProcessCancel(bookingId);
            if (!isDeleted)
                return BadRequest(new
                {
                    Success =false,
                    Message = "Booking not found"
                });
            return Ok(new
            {
                Success=true,
                Message="Booking cancelled successfully"
            });
        }


    }
}
