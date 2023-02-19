using FluentValidation;
using Radisson.Domain.Business.AboutModule.Teams;

namespace Radisson.Domain.Validators.AboutModuleValidators.TeamsValidators
{
    public class TeamPostCommandValidator : AbstractValidator<TeamPostCommand>
    {
        public TeamPostCommandValidator()
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
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.ImagePath)
               .NotEmpty()
               .WithMessage("Şəkil seçilməyib!");
        }
    }
}
