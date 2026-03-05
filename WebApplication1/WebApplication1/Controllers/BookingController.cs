using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly OpaService _opaService;
        private string LOGIN_REQUIRED = "Login to book a Concert.\nNew User? Sign up";
        public BookingController(IBookingService bookingService,OpaService opaService)
        {
            _opaService = opaService;
            _bookingService = bookingService;
        }
        [HttpPost]
        public async Task<ActionResult<BookingResDto>> Create(BookingReqDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (userId == null)
                return Unauthorized(new
                {
                    Message=LOGIN_REQUIRED
                });
            var role = User.FindFirst(ClaimTypes.Role)?.Value?.ToUpper();
            bool allowed = role != null ? await _opaService.IsAllowed(int.Parse(userId),role, "create_booking", "booking") : false;
            Booking booking = BookingMapper.ToEntity(request);
            if (!allowed)
                return Forbid();
            booking.UserId = int.Parse(userId);
            Booking createdBooking=_bookingService.BookConcert(booking);
            BookingResDto response = BookingMapper.ToResponse(createdBooking);
            return Ok(response);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingResDto>>> Get()
        {
            
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;           
            if (userId==null)
                return Unauthorized(new
                {
                    Message = LOGIN_REQUIRED
                });
            var role = User.FindFirst(ClaimTypes.Role)?.Value?.ToUpper();
            bool allowed = role != null ? await _opaService.IsAllowed(int.Parse(userId),role, "view_bookings", "booking") : false;

            if (!allowed)
                return StatusCode(403, new
                {
                    role = role,
                    isAllowed = allowed
                });
            // return Forbid();
            IEnumerable < BookingResDto> response = _bookingService.Get(int.Parse(userId));
            return Ok(response);
        }
    }
}
