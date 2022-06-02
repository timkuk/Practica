using Booking.BLL.DTOs.RequestHelpers;
using MediatR;

namespace Booking.BLL.CQRS.Filters
{
    public class Query : IRequest<AdvertisementFilterDto>
    {

    }
}
