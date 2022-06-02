using System.Collections.Generic;

namespace Booking.BLL.DTOs.AdvertiesementAggregate
{
    public class AdvertiesementDto
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public long Rooms { get; set; }

        public double LivingArea { get; set; }

        public long Floor { get; set; }

        public IEnumerable<string> Images { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string PublicationDate { get; set; }

        public AdvertisementLocationDto Location { get; set; }
    }
}
