using FluentValidation;
using Radisson.Domain.Business.AboutModule.RadissonHotels;
using System.Linq;

namespace Radisson.Domain.Validators.AboutModuleValidators.RadissonHotelsValidators
{
    public class RadissonHotelPostCommandValidator : AbstractValidator<RadissonHotelPostCommand>
    {
        public RadissonHotelPostCommandValidator()
        {
            RuleFor(entity => entity.Title)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!")
               .MaximumLength(40)
               .WithMessage("Bu hissənin uzunluğu maksimum 40 olmalıdır!");
            RuleFor(entity => entity.Text)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            RuleFor(entity => entity.Image)
               .NotEmpty()
               .WithMessage("Boş buraxıla bilməz!");
            //RuleFor(m => m.Images)
            //    .Custom((list, context) =>
            //    {
            //        if (list == null)
            //        {
            //            context.AddFailure("Şəkil seçilməyib!");
            //        }
            //        else if (list.Count(l => l.IsMain == true) == 0)
            //        {
            //            context.AddFailure("Esas sekil secilmeyib");
            //        }
            //    });

            //RuleForEach(m => m.Images)
            //    .ChildRules(m =>
            //    {
            //        m.RuleFor(i => i.File != null);
            //    });
        }
    }
}
