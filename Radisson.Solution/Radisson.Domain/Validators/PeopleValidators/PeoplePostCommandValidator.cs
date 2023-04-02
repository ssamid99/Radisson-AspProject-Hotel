using FluentValidation;
using Radisson.Domain.Business.PeopleModule;

namespace Radisson.Domain.Validators.PeopleValidators
{
    public class PeoplePostCommandValidator : AbstractValidator<PeoplePostCommand>
    {
        public PeoplePostCommandValidator()
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
