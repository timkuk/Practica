using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using System;

namespace Booking.BLL.CQRS.Advertisement.Get
{
    public class Query : IRequest<AdvertisementEntity>
    {
        public Guid AdvertisementId { get; }

        public Query(Guid id) => AdvertisementId = id;
    }
}
