using AutoMapper;
using WebApplication1.DTO.Response;
using WebApplication1.DTO.Request;
using WebApplication1.Models;
namespace WebApplication1.Mapper
{
    public class AutoProfileMapper : Profile
    {
      
        public AutoProfileMapper()
        {
           
            CreateMap<Hall, HallDto>()
                .ForMember(dto=>dto.ownerId,
                opt=>opt.MapFrom(h=>h.HallOwner.UserId));
            CreateMap<HallDto, Hall>();
            CreateMap<HallBooking, HallBookingDto>()
                .ForMember(dto=>dto.HallName,
                opt=>opt.MapFrom(hb=>hb.Hall.HallName))
                .ForMember(dto=>dto.userEmail,
                opt=>opt.MapFrom(hb=>hb.User.Email));
            CreateMap<HallBookingReqDto, HallBooking>();
            CreateMap<HallBookingDto, HallBooking>();
            CreateMap<ConcertSpec, ConcertSpecDto>();
            CreateMap<ConcertSpecReqDto, ConcertSpec>();
            CreateMap<User, UserResDto>()
                .ForMember(dto=>dto.Concerts,
                opt=>opt.MapFrom(u=>u.Concerts))
                .ForMember(dto=>dto.Bookings,
                opt=>opt.MapFrom(u=>u.Bookings));

            CreateMap<Booking, BookingResDto>()
                .ForMember(dto=>dto.UserName,
                opt=>opt.MapFrom(b=>b.Audience.UserName))
                .ForMember(dto=>dto.UserEmail,
                opt=>opt.MapFrom(b=>b.Audience.Email))
                .ForMember(dto=>dto.Concert,
                opt=>opt.MapFrom(b=>b.Concert));

            CreateMap<Concert, ConcertResDto>()
                .ForMember(c=> c.ConcertSpec,
                opt => opt.MapFrom(dto => dto.ConcertSpecs))
                .ForMember(dto => dto.HallName,
                 opt => opt.MapFrom(hb =>
                 hb.HallBookings
                .FirstOrDefault(hb => hb.Hall != null).Hall.HallName));
            CreateMap<ConcertReqDto, Concert>()
                .ForMember(c=>c.ConcertSpecs,
                opt=>opt.MapFrom(req=>req.ConcertSpec));
        }
    }
}
