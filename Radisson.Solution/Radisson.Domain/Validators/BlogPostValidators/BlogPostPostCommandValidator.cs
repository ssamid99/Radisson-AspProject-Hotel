using FluentValidation;
using Radisson.Domain.Business.BlogPostModule;

namespace Radisson.Domain.Validators.BlogPostValidators
{
    public class BlogPostPostCommandValidator : AbstractValidator<BlogPostPostCommand>
    {
        public BlogPostPostCommandValidator()
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

            RuleFor(entity => entity.Image)
                .NotEmpty()
                .WithMessage("Şəkil seçilməyib!");
        }
    }
}
