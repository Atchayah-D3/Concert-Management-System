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
             
                Date_Time=request.Date_Time,
                Price=request.Price,
                ConcertId=request.ConcertId
            };
        }

        public static ConcertSpecDto ToResponse(ConcertSpec concertSpec)
        {
            return new ConcertSpecDto
            {
                ConcertId = concertSpec.ConcertId,
                ConcertSpecId=concertSpec.ConcertSpecId,
                Artist=concertSpec.Artist,
               
                Date_Time=concertSpec.Date_Time,
                Price=concertSpec.Price

            };

        }
    }
}
