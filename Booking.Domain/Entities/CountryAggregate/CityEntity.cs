using System;
using Booking.Domain.Attributes;
using Booking.Domain.Documents;

namespace Booking.Domain.Entities.CountryAggregate
{
    [BsonCollection("Cities")]
    public class CityEntity : Document
    {
        public string Name { get; set; }
        
        public Guid CountryId { get; set; }
    }
}
