using BloggingPlatform.Domain.Features.BlogPosts;
using BloggingPlatform.Domain.Features.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Configurations;
internal sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(comment => comment.Id);
        builder.Property(comment => comment.Id)
            .HasConversion(id => id.Value, value => new CommentId(value));

        builder.Property(comment => comment.Text)
            .HasColumnName("text")
            .IsRequired();

        builder.HasOne<BlogPost>()
            .WithMany(bp => bp.Comments)
            .HasForeignKey(comment => comment.BlogPostId);
    }
}
