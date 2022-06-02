using System.Collections.Generic;

namespace Booking.BLL.DTOs.RequestHelpers
{
    public class AdvertisementFilterDto : PaginationParams
    {
        public IEnumerable<string> Countries { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public double MaxPrice { get; set; }

        public double MinPrice { get; set; }

        public long Rooms { get; set; }
    }
}
