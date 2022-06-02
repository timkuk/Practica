﻿namespace Booking.BLL.DTOs.RequestHelpers
{
    public class PaginationParams
    {
        private const int MaxPageSize = 6;

        private int _pageSize = 6;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < MaxPageSize ? MaxPageSize : value;
        }
    }
}
