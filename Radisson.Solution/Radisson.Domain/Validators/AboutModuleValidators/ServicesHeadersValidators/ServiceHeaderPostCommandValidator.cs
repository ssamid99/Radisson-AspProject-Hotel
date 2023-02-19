using FluentValidation;
using Radisson.Domain.Business.AboutModule.ServicesHeaders;

namespace Radisson.Domain.Validators.AboutModuleValidators.ServicesHeadersValidators
{
    public class ServicesHeaderPostCommandValidator : AbstractValidator<ServiceHeaderPostCommand>
    {
        public ServicesHeaderPostCommandValidator()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(40)
               .WithMessage("Bu hissənin uzunluğu maksimum 40 olmalıdır!");
        }
    }
}
