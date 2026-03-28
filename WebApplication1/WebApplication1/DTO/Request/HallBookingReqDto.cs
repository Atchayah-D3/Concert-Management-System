using WebApplication1.ModelValidation;

namespace WebApplication1.DTO.Request
{
    public class HallBookingReqDto
    {
        public int HallId { get; set; }
        public int ConcertId { get; set; }
        public DateTime FromDateTime { get; set; }
        [BookingDateTime]
        public DateTime ToDateTime { get; set; }
    }
}
