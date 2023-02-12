using FluentValidation;
using Radisson.Domain.Models.Entities;
using System.Linq;

namespace Radisson.Domain.Validators
{
    public class ServicesBodyValidators : AbstractValidator<ServicesBody>
    {
        public ServicesBodyValidators()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(25)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.ImagePath)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.ServicesHeaderId)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
