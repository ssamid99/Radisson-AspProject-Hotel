using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators.BlogPostValidators
{
    public class BlogPostValidator : AbstractValidator<BlogPost>
    {
        public BlogPostValidator()
        {
            RuleFor(entity => entity.Title)
                .NotEmpty()
                .WithMessage("Boş buraxıla bilməz!")
                .MaximumLength(150)
                .WithMessage("Bu hissənin uzunluğu maksimum 150 olmalıdır!");

            RuleFor(entity => entity.Body)
                .NotEmpty()
                .WithMessage("Boş buraxıla bilməz!")
                .MinimumLength(120)
                .WithMessage("Bu hissənin uzunluğu minimum 120 olmalıdır!");

            RuleFor(entity => entity.ImagePath)
                .NotEmpty()
                .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
