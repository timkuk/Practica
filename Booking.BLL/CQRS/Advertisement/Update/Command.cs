using Booking.BLL.DTOs.AdvertiesementAggregate;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;

namespace Booking.BLL.CQRS.Advertisement.Update
{
    public class Command : IRequest<AdvertisementEntity>
    {
        public AdvertiesementDto UpdateAdvertiesementDto { get; }

        public Command(AdvertiesementDto updateAdvertiesementDto) => UpdateAdvertiesementDto = updateAdvertiesementDto;
    }
}