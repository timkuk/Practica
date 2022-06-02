using Booking.Domain.Entities.AdvertiesementAggregate;
using System.Linq;
using Booking.BLL.DTOs.RequestHelpers;

namespace Booking.BLL.Extensions
{
    public static class AdvertisementExtensions
    {
        public static IQueryable<AdvertisementEntity> Filter(this IQueryable<AdvertisementEntity> query, AdvertisementFilterDto filters)
        {
            filters.Countries ??= query.Select(a => a.Location.Country.Name).Distinct();
            filters.Cities ??= query.Select(a => a.Location.City.Name).Distinct();
            
            switch (filters.Rooms)
            {
                case <= 0:
                    filters.Rooms = query.Max(a => a.Rooms);
                    query = query.Where(a => a.Rooms <= filters.Rooms);
                    break;
                case 4:
                    query = query.Where(a => a.Rooms >= filters.Rooms);
                    break;
                default:
                    query = query.Where(a => a.Rooms == filters.Rooms);
                    break;
            }
            
            if (filters.MaxPrice <= 0)
            {
                filters.MaxPrice = query.Max(a => a.Price);
            }
            
            if (filters.MinPrice <= 0)
            {
                filters.MinPrice = query.Min(a => a.Price);
            }
            
            var countries = string.Join("", filters.Countries);
            var cities = string.Join(",", filters.Cities);
            
            return query
                    .Where(a => countries.Contains(a.Location.Country.Name))
                    .Where(a => cities.Contains(a.Location.City.Name))
                    .Where(a => a.Price >= filters.MinPrice && a.Price <= filters.MaxPrice);
        }
    }
}
