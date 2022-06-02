using FluentValidation;

namespace Booking.BLL.CQRS.Account.Login
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.LoginDto)
                .NotNull();
        }
    }
}