using Booking.Domain.Documents;
using Booking.Domain.Entities.CountryAggregate;

namespace Booking.Domain.Entities.AdvertiesementAggregate
{
    public class AdvertisementLocationEntity : Document
    {
        public CountryEntity Country { get; set; }

        public CityEntity City { get; set; }

        public string Address { get; set; }

        public string Geolocation { get; set; }
    }
}
