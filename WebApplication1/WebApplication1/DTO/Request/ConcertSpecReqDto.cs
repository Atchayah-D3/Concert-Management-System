using System.ComponentModel.DataAnnotations;
using WebApplication1.ModelValidation;

namespace WebApplication1.DTO.Request
{
    public class ConcertSpecReqDto
    {
        public string? Artist { get; set; }
        public string? Venue { get; set; }
        [DataType(DataType.DateTime)]
        [ConcertDateTime]
        public DateTime? Date_Time { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Price cannot be negative")]
        public decimal? Price { get; set; }
        public int ConcertId { get; set; }
    }
}
