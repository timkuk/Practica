namespace Booking.BLL.DTOs.RequestHelpers
{
    public class MetaData
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public double PageSize { get; set; }

        public int TotalCount { get; set; }
    }
}
