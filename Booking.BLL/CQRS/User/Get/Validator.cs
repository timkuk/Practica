using FluentValidation;

namespace Booking.BLL.CQRS.User.Get
{
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(q => q.UserName)
                .NotNull()
                .NotEmpty();
        }
    }
}