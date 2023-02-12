using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class RoomValidators : AbstractValidator<Room>
    {
        public RoomValidators()
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
