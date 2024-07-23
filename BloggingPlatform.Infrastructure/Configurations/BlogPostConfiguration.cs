using BloggingPlatform.Domain.BlogPosts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingPlatform.Infrastructure.Configurations;
internal sealed class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("blog_posts");

        builder.HasKey(blogPost => blogPost.Id);
        builder.Property(blogPost => blogPost.Id)
            .HasConversion(id => id.Value, value => new BlogPostId(value));

        builder.Property(blogPost => blogPost.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(blogPost => blogPost.Content)
            .HasColumnName("content")
            .IsRequired();

        builder.Property(blogPost => blogPost.Status)
            .HasConversion(
                value => value.ToString(),
                value => (EBlogStatus)Enum.Parse(typeof(EBlogStatus), value)
            );
    }
}
