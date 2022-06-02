using FluentValidation;

namespace Booking.BLL.CQRS.Account.Register
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.RegisterDto)
                .NotNull();
        }
    }
}