using FluentValidation;

namespace Booking.BLL.CQRS.Advertisement.Create
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.CreateAdvertiesementDto)
                .NotNull();
        }
    }
}
