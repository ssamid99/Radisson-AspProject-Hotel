using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radisson.Domain.Models.Entities;

namespace Radisson.Domain.Models.DataContexts.Configurations.BlogPost
{
    public class BlogPostCommentEntityTypeConfiguration : IEntityTypeConfiguration<BlogPostComment>
    {
        public void Configure(EntityTypeBuilder<BlogPostComment> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.Id)
                .UseIdentityColumn();

            builder.Property(entity => entity.Text)
                .IsRequired();

            builder.Property(entity => entity.BlogPostId)
                .IsRequired();
        }
    }
}
