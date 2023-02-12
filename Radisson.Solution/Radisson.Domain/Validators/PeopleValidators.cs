using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class PeopleValidators : AbstractValidator<People>
    {
        public PeopleValidators()
        {
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(60)
               .WithMessage("Bu hissənin uzunluğu maksimum 60 olmalıdır!");
            RuleFor(entity => entity.Price)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
