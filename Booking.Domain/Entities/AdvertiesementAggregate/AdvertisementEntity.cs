using Booking.Domain.Attributes;
using System.Collections.Generic;
using Booking.Domain.Documents;

namespace Booking.Domain.Entities.AdvertiesementAggregate
{
    [BsonCollection("Advertisements")]
    public class AdvertisementEntity : Document
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

        public AdvertisementLocationEntity Location { get; set; }
    }
}
