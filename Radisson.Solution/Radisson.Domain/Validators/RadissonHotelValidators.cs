using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class RadissonHotelValidators : AbstractValidator<RadissonHotel>
    {
        public RadissonHotelValidators()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(40)
               .WithMessage("Bu hissənin uzunluğu maksimum 40 olmalıdır!");
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
