using Booking.BLL.DTOs.AdvertiesementAggregate;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;

namespace Booking.BLL.CQRS.Advertisement.Create
{
    public class Command : IRequest<AdvertisementEntity>
    {
        public AdvertiesementDto CreateAdvertiesementDto { get; }

        public Command(AdvertiesementDto createAdvertiesementDto) => CreateAdvertiesementDto = createAdvertiesementDto;
    }
}
