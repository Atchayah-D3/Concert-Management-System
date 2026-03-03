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
        private string LOGIN_REQUIRED = "Login to book a Concert.\nNew User? Sign up";
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public ActionResult<BookingResDto> Create(BookingReqDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Booking booking = BookingMapper.ToEntity(request);
            if (userId == null)
                return Unauthorized(new
                {
                    Message=LOGIN_REQUIRED
                });

            booking.UserId = int.Parse(userId);
            Booking createdBooking=_bookingService.BookConcert(booking);
            BookingResDto response = BookingMapper.ToResponse(createdBooking);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingResDto>> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userId==null)
                return Unauthorized(new
                {
                    Message = LOGIN_REQUIRED
                });           
            IEnumerable < BookingResDto> response = _bookingService.Get(int.Parse(userId));
            return Ok(response);
        }
    }
}
