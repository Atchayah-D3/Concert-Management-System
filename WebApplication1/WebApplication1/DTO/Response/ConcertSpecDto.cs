using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class ConcertSpecDto
    {
        public int ConcertSpecId { get; set; }
        public string? Artist { get; set; }
        public DateTime? Date_Time { get; set; }
        public decimal? Price { get; set; }
        public int ConcertId { get; set; }
       
    }
}
