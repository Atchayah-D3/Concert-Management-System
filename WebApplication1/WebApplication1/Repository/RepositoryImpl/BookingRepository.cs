
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTO.Response;
using WebApplication1.Mapper;
using WebApplication1.Models;

namespace WebApplication1.Repository.RepositoryImpl
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _dbContext;
        public BookingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Booking BookConcert(Booking booking)
        {
            _dbContext.Add(booking);
            _dbContext.SaveChanges();
            return _dbContext.Bookings
                .Include(b=>b.Concert)
                .ThenInclude(c=>c.ConcertSpecs)
                .Include(b=>b.Audience)
                .First(b=>b.BookingId==booking.BookingId);
        }
        public IEnumerable<BookingResDto> Get(int userId)
        {
            return _dbContext.Bookings
                .Where(b=>b.UserId==userId)
                .Select(b => new BookingResDto
                {
                    BookingId=b.BookingId,
                    Concert = new ConcertResDto
                    {
                        ConcertId = b.Concert.ConcertId,
                        ConcertName = b.Concert.ConcertName,
                        ConcertSpec =ConcertSpecMapper.ToResponse(b.Concert.ConcertSpecs)
                    },
                    UserName=b.Audience.UserName,
                    UserEmail=b.Audience.Email,
                    Status=b.Status,
                    BookingTime=b.BookingTime
                })
                .ToList();
        }
    }
}
