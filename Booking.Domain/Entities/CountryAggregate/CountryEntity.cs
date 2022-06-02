using Booking.Domain.Attributes;
using System.Collections.Generic;
using Booking.Domain.Documents;

namespace Booking.Domain.Entities.CountryAggregate
{
    [BsonCollection("Countries")]
    public class CountryEntity : Document
    {
        public string Name { get; set; }
    }
}
