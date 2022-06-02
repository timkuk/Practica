using FluentValidation;

namespace Booking.BLL.CQRS.Advertisement.Update
{
    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.UpdateAdvertiesementDto)
                .NotNull();
        }
    }
}
