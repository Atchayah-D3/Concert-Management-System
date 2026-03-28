using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class HallBooking
    {
        public int HallBookingId { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public double Price { get; set; }
        public BookingStatus Status { get; set; }
        public int HallId { get; set; }
        [JsonIgnore]
        public Hall? Hall { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int? ConcertId { get; set; }
        [JsonIgnore]
        public Concert? Concert { get; set; }
    }
}