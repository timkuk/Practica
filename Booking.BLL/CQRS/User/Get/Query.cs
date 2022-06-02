using Booking.BLL.DTOs.AuthAggregate;
using MediatR;

namespace Booking.BLL.CQRS.User.Get
{
    public class Query : IRequest<UserDto>
    {
        public string UserName { get; }
        
        public Query(string userName)
        {
            UserName = userName;
        }
    }
}