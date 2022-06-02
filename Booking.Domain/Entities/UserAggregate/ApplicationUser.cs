using System;
using AspNetCore.Identity.MongoDbCore.Models;
using Booking.Domain.Attributes;
using Booking.Domain.Interfaces;

namespace Booking.Domain.Entities.UserAggregate
{
    [BsonCollection("Users")]
    public class ApplicationUser : MongoIdentityUser<Guid>, IDocument
    {
        
    }
}