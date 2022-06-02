using System;
using AspNetCore.Identity.MongoDbCore.Models;
using Booking.Domain.Attributes;
using Booking.Domain.Interfaces;

namespace Booking.Domain.Entities.UserAggregate
{
    [BsonCollection("Roles")]
    public class ApplicationRole: MongoIdentityRole<Guid>, IDocument
    {
        
    }
}