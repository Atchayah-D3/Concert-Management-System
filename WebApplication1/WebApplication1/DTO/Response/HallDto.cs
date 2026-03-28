using System.Text.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class HallDto
    {

        public int HallId { get; set; }
        public string HallName { get; set; }
        public string Location { get; set; }
        public int capacity { get; set; }
        public List<HallBookingDto>? Bookings { get; set; } = null;
        public double PricePerHour { get; set; }
        public int ownerId { get; set; }
        [JsonIgnore]
        public User? HallOwner { get; set; }
    }
}