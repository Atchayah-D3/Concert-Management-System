using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class BookingMapper
    {
        public static Booking ToEntity(BookingReqDto dto)
        {
            return new Booking
            {
                ConcertId=dto.ConcertId,
            };
        }
        public static BookingResDto ToResponse(Booking booking)
        {
            return new BookingResDto
            {
                BookingId=booking.BookingId,
                BookingTime=booking.BookingTime,
                Concert=ConcertMapper.ToResponse(booking.Concert),
                UserName=booking.Audience.UserName,
                UserEmail=booking.Audience.Email,
                Status=booking.Status
            };
        }
    }
}
