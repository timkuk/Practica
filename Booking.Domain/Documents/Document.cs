using System;
using Booking.Domain.Interfaces;

namespace Booking.Domain.Documents
{
    public class Document : IDocument
    {
        public Guid Id { get; set; }
    }
}
