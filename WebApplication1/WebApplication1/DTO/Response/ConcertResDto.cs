using System.Text.Json.Serialization;

namespace WebApplication1.DTO.Response
{
    public class ConcertResDto
    {
        public int ConcertId { get; set; }
        public required string ConcertName { get; set; }
        public  ConcertSpecDto ConcertSpec { get; set; } 
        public int CreatorId { get; set; }
     
        public string? HallName { get; set; }
       
        public string? CustomHall { get; set; }
        public ICollection<HallBookingDto> HallBookings { get; set; } = null!;    
    }
}
