using FluentValidation;

namespace Booking.BLL.CQRS.Advertisement.Details
{
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(q => q.Response)
                .NotNull();
        }
    }
}
