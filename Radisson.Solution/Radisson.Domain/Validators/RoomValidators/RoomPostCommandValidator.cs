using FluentValidation;
using Radisson.Domain.Business.RoomModule;

namespace Radisson.Domain.Validators.RoomValidators
{
    public class RoomPostCommandValidator : AbstractValidator<RoomPostCommand>
    {
        public RoomPostCommandValidator()
        {
            RuleFor(entity => entity.Number)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.RoomTypeId)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
