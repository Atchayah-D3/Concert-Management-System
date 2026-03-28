using Npgsql;

namespace WebApplication1.Models
{
    public class Hall
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public string Location { get; set; }
        public int capacity { get; set; }
        public int hallOwnerId { get; set; }
        public User? HallOwner { get; set; }
        public List<HallBooking>? Bookings { get; set; } = new List<HallBooking>();
        public double PricePerHour { get; set; }
    }
}
