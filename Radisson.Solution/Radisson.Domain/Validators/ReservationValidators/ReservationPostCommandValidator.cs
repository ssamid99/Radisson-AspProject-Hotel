using FluentValidation;
using Radisson.Domain.Business.ReservationModule;

namespace Radisson.Domain.Validators.ReservationValidators
{
    public class ReservationPostCommandValidator : AbstractValidator<ReservationPostCommand>
    {
        public ReservationPostCommandValidator()
        {
            RuleFor(entity => entity.Name)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(25)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.Surname)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(35)
               .WithMessage("Bu hissənin uzunluğu maksimum 25 olmalıdır!");
            RuleFor(entity => entity.Email)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .EmailAddress()
               .WithMessage("Yanlış email adresi!")
               .MaximumLength(45)
               .WithMessage("Bu hissənin uzunluğu maksimum 45 olmalıdır!");
            RuleFor(entity => entity.CheckIn)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.CheckOut)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.RoomTypeId)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.P1)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.P2)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.P3)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
