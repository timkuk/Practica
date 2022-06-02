using Booking.BLL.DTOs.RequestHelpers;
using Booking.DAL.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.BLL.CQRS.Filters
{
    public class Handler : IRequestHandler<Query, AdvertisementFilterDto>
    {
        private readonly IAdvertisementRepository _advertisementRepository;

        public Handler(IAdvertisementRepository advertisementRepository) => _advertisementRepository = advertisementRepository;

        public async Task<AdvertisementFilterDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = (await _advertisementRepository.GetAllAsync()).AsQueryable();

            var countries = query.Select(p => p.Location.Country.Name).Distinct().ToList();
            var cities = query.Select(p => p.Location.City.Name).Distinct().ToList();
            var minPrice = query.Min(a => a.Price);
            var maxPrice = query.Max(a => a.Price);
            var rooms = query.Min(a => a.Rooms);
            
            return new AdvertisementFilterDto
            {
                Countries = countries,
                Cities = cities,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Rooms = rooms
            };
        }
    }
}
