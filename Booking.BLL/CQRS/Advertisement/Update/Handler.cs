using AutoMapper;
using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.BLL.CQRS.Advertisement.Update
{
    public class Handler : IRequestHandler<Command, AdvertisementEntity>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _advertisementRepository;

        public Handler(IMapper mapper, IAdvertisementRepository advertisementRepository)
        {
            _mapper = mapper;
            _advertisementRepository = advertisementRepository;
        }

        public async Task<AdvertisementEntity> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = _mapper.Map<AdvertisementEntity>(request.UpdateAdvertiesementDto);

            await _advertisementRepository.UpdateAsync(advertisement);

            return null;
        }
    }
}
