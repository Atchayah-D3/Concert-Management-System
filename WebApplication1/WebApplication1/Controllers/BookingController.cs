using AutoMapper;
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
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly OpaService _opaService;
        private string LOGIN_REQUIRED = "Login to book a Concert.\nNew User? Sign up";
        public BookingController(IBookingService bookingService,
            IUserService userService,
            OpaService opaService,
            IMapper mapper)
        {
            _opaService = opaService;
            _userService = userService;
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<BookingResDto>> Create(BookingReqDto request)
        {
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userId==0)
                return Unauthorized(new
                {
                    Message=LOGIN_REQUIRED
                });
            bool allowed = role != null ? await _opaService.IsAllowed(userId,role, "create_booking", "booking") : false;
            Booking booking = BookingMapper.ToEntity(request);
            if (!allowed)
                return Forbid();
            booking.UserId = userId;
            Booking createdBooking=_bookingService.BookConcert(booking);
            BookingResDto response = _mapper.Map<BookingResDto>(createdBooking);
            return Ok(response);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingResDto>>> Get()
        {
            string UUID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            int userId = await _userService.GetUserId(UUID);
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;           
            if (userId==null)
                return Unauthorized(new
                {
                    Message = LOGIN_REQUIRED
                });
            bool allowed = role != null ? await _opaService.IsAllowed(userId,role, "view_bookings", "booking") : false;

            if (!allowed)
                 return Forbid();
            IEnumerable < BookingResDto> response = _bookingService.Get(userId);
            return Ok(response);
        }
        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult> CancellBooking(int id) 
        {
            string message = _bookingService.CancelBooking(id);
            if(message.Contains("successfully"))
             return Ok(message);
            return BadRequest(message);
        }
    }
}
