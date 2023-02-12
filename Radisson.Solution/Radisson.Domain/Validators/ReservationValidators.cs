using FluentValidation;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Validators
{
    public class ReservationValidators : AbstractValidator<Reservation>
    {
        public ReservationValidators()
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
        }
    }
}
