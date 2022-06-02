using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Booking.Domain.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
