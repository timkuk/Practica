using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.BLL.CQRS.Advertisement.Get
{
    public class Handler : IRequestHandler<Query, AdvertisementEntity>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public Handler(IAdvertisementRepository advertisementRepository) => _advertisementRepository = advertisementRepository;

        public async Task<AdvertisementEntity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _advertisementRepository.GetByIdAsync(request.AdvertisementId);
        } 
    }
}
