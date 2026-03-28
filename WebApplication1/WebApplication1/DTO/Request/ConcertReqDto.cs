using System.Text.Json.Serialization;
using WebApplication1.DTO.Response;
using WebApplication1.Models;
namespace WebApplication1.DTO.Request

{
    public class ConcertReqDto
    {
        public required string ConcertName { get; set; }
        public ConcertSpecReqDto? ConcertSpec { get; set; } = null;
        public string? CustomHall { get; set; }
        public HallBookingReqDto? HallBookingReq { get; set; } = null;
    }
}
