using Booking.BLL.DTOs.CountryAggregate;

namespace Booking.BLL.DTOs.AdvertiesementAggregate
{
    public class AdvertisementLocationDto
    {
        public CountryDto Country { get; set; }

        public CityDto City { get; set; }

        public string Address { get; set; }

        public string Geolocation { get; set; }
    }
}
