using FluentValidation;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Validators.BlogPostValidators
{
    public class BlogPostCommentValidator : AbstractValidator<BlogPostComment>
    {
        public BlogPostCommentValidator()
        {
            RuleFor(entity => entity.Text)
                .NotEmpty()
                .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
