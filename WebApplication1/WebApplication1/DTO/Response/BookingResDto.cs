using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class BookingResDto
    {
        public int BookingId { get; set; }
        public ConcertResDto Concert { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public BookingStatus Status { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
