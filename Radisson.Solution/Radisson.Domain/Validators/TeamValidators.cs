using FluentValidation;
using Radisson.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radisson.Domain.Validators
{
    public class TeamValidators : AbstractValidator<Team>
    {
        public TeamValidators()
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
               .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
