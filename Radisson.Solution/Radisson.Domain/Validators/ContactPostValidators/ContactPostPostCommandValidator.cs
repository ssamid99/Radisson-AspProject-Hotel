using FluentValidation;
using Radisson.Domain.Business.ContactPostModule;

namespace Radisson.Domain.Validators.ContactPostValidators
{
    public class ContactPostPostCommandValidator : AbstractValidator<ContactPostPostCommand>
    {
        public ContactPostPostCommandValidator()
        {
            RuleFor(entity => entity.Name)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(20)
               .WithMessage("Bu hissənin uzunluğu maksimum 20 olmalıdır!");
            RuleFor(entity => entity.Surname)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(35)
               .WithMessage("Bu hissənin uzunluğu maksimum 35 olmalıdır!");
            RuleFor(entity => entity.Email)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .EmailAddress()
               .WithMessage("Yanlış email adresi!")
               .MaximumLength(45)
               .WithMessage("Bu hissənin uzunluğu maksimum 45 olmalıdır!");
            RuleFor(entity => entity.Phone)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(30)
               .WithMessage("Bu hissənin uzunluğu maksimum 30 olmalıdır!");
            RuleFor(entity => entity.Message)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
