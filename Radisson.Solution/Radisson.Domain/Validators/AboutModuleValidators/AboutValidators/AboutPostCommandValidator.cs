using FluentValidation;
using Radisson.Domain.Business.AboutModule.Abouts;

namespace Radisson.Domain.Validators.AboutModuleValidators
{
    public class AboutPostCommandValidator : AbstractValidator<AboutPostCommand>
    {
        public AboutPostCommandValidator()
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
