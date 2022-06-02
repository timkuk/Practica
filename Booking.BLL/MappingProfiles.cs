using AutoMapper;
using Booking.BLL.DTOs.AdvertiesementAggregate;
using Booking.Domain.Entities.AdvertiesementAggregate;

namespace Booking.BLL
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AdvertiesementDto, AdvertisementEntity>().ReverseMap();
        }
    }
}
