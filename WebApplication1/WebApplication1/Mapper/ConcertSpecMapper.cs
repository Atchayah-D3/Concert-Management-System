using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class ConcertSpecMapper
    {
        public static ConcertSpec ToEntity(ConcertSpecReqDto request)
        {
            return new ConcertSpec
            {
                Artist = request.Artist,
                Venue=request.Venue,
                Date_Time=request.Date_Time,
                Price=request.Price,
                ConcertId=request.ConcertId
            };
        }

        public static ConcertSpecResDto ToResponse(ConcertSpec concertSpec)
        {
            return new ConcertSpecResDto
            {
                ConcertId = concertSpec.ConcertId,
                ConcertSpecId=concertSpec.ConcertSpecId,
                Artist=concertSpec.Artist,
                Venue=concertSpec.Venue,
                Date_Time=concertSpec.Date_Time,
                Price=concertSpec.Price

            };

        }
    }
}
