using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class AboutValidators : AbstractValidator<About>
    {
        public AboutValidators()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(25)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.Count)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
