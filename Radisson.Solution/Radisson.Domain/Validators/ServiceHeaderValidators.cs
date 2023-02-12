using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators
{
    public class ServiceHeaderValidators : AbstractValidator<ServicesHeader>
    {
        public ServiceHeaderValidators()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(40)
               .WithMessage("Bu hissənin uzunluğu maksimum 40 olmalıdır!");
        }
    }
}
