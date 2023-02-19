using FluentValidation;
using Radisson.Domain.Business.BlogPostModule;

namespace Radisson.Domain.Validators.BlogPostValidators
{
    public class BlogPostCommentPostCommandValidator : AbstractValidator<BlogPostCommentPostCommand>
    {
        public BlogPostCommentPostCommandValidator()
        {
            RuleFor(entity => entity.comment)
                .NotEmpty()
                .WithMessage("Boş buraxıla bilməz!");
        }
    }
}
