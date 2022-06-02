using AutoMapper;
using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.BLL.CQRS.Advertisement.Create
{
    public class Handler : IRequestHandler<Command, AdvertisementEntity>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _advertisementRepository;

        public Handler(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        public async Task<AdvertisementEntity> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = _mapper.Map<AdvertisementEntity>(request.CreateAdvertiesementDto);

            await _advertisementRepository.AddAsync(advertisement);

            return null;
        }
    }
}
