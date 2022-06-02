using FluentValidation;

namespace Booking.BLL.CQRS.Advertisement.Get
{
    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(q => q.AdvertisementId)
                .NotNull();
        }
    }
}
