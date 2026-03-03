using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebApplication1.ModelValidation;

namespace WebApplication1.Models
{
    public class ConcertSpec
    {
        public int ConcertSpecId { get; set; }
        
        public DateTime? Date_Time { get; set; }
        public string? Artist { get; set; }
        public string? Venue { get; set; }
        
        public decimal? Price { get; set; }
        public int ConcertId { get; set; }
        [JsonIgnore]
        public Concert? Concert { get; set; }
    }
}
