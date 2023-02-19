using FluentValidation;
using Radisson.Domain.Business.RoomTypeModule;

namespace Radisson.Domain.Validators.RoomTypeValidators
{
    public class RoomTypePostCommandValidators : AbstractValidator<RoomTypePostCommand>
    {
        public RoomTypePostCommandValidators()
        {
            RuleFor(entity => entity.Name)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(25)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.PriceInclude)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.Price)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.ImagePath)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
