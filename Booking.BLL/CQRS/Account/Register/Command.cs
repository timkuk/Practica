using Booking.BLL.DTOs.AuthAggregate;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Booking.BLL.CQRS.Account.Register
{
    public class Command : IRequest<IdentityResult>
    {
        public RegisterDto RegisterDto { get; }
        
        public Command(RegisterDto registerDto)
        {
            RegisterDto = registerDto;
        }
    }
}