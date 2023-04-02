using FluentValidation;
using Radisson.Domain.Business.AboutModule.ServicesBodies;

namespace Radisson.Domain.Validators.AboutModuleValidators.ServicesBodiesValidators
{
    public class ServicesBodyPostCommandValidator : AbstractValidator<ServiceBodyPostCommand>
    {
        public ServicesBodyPostCommandValidator()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(25)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.Image)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.ServicesHeaderId)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
