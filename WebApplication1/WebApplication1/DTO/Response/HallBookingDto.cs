using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class HallBookingDto
    {
        public int? HallBookingId { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public double? Price { get; set; }
        public BookingStatus? Status { get; set; }
        public string  userEmail { get; set; }
        public string HallName { get; set; }
    }
}
