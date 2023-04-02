using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators.SubscribeValidators
{
    public class SubscribeValidator : AbstractValidator<Subscribe>
    {
        public SubscribeValidator()
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
