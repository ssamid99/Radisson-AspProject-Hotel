using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class SubscribeValidators : AbstractValidator<Subscribe>
    {
        public SubscribeValidators()
        {
            RuleFor(entity => entity.Email)
              .NotEmpty()
              .WithMessage("Boş buraxıla bilməz!")
              .EmailAddress()
              .WithMessage("Yanlış email adresi!")
              .MaximumLength(45)
              .WithMessage("Bu hissənin uzunluğu maksimum 45 olmalıdır!");
        }
    }
}
