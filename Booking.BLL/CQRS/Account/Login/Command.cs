using Booking.BLL.DTOs.AuthAggregate;
using MediatR;

namespace Booking.BLL.CQRS.Account.Login
{
    public class Command : IRequest<UserDto>
    {
        public LoginDto LoginDto { get; }
        
        public Command(LoginDto loginDto)
        {
            LoginDto = loginDto;
        }
    }
}