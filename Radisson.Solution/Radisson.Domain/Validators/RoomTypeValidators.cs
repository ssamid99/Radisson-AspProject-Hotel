using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class RoomTypeValidators : AbstractValidator<RoomType>
    {
        public RoomTypeValidators()
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
