using FluentValidation;
using Radisson.Domain.Business.RadissonRoleModule;

namespace Radisson.Domain.Validators.RadissonRoleValidators
{
    public class RadissonRolePostCommandValidator : AbstractValidator<RadissonRolePostCommand>
    {
        public RadissonRolePostCommandValidator()
        {
            RuleFor(entity => entity.Name)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(40)
               .WithMessage("Bu hissənin uzunluğu maksimum 40 olmalıdır!");
        }
    }
}
