using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Booking.BLL.DTOs.RequestHelpers;
using Booking.DAL.Interfaces;
using Booking.Domain.Entities.AdvertiesementAggregate;
using MediatR;
using System.Linq;
using Booking.BLL.Extensions;

namespace Booking.BLL.CQRS.Advertisement.Details
{
    public class Handler : IRequestHandler<Query, IEnumerable<AdvertisementEntity>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public Handler(IAdvertisementRepository advertisementRepository) => _advertisementRepository = advertisementRepository;

        public async Task<IEnumerable<AdvertisementEntity>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = (await _advertisementRepository.GetAllAsync()).AsQueryable()
                .Filter(request.AdvertisementFilters);

            var result = PagedList<AdvertisementEntity>.ToPagedList(
                query, request.AdvertisementFilters.PageNumber, request.AdvertisementFilters.PageSize);
            
            request.Response.AddPaginationHeader(result.MetaData);
            
            return result;
        }
    }
}
