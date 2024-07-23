using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.BlogPosts;

namespace BloggingPlatform.Domain.Comments;
public class Comment : Entity<CommentId>
{
    public Comment(BlogPostId blogPostId, string text) : base(CommentId.New())
    {
        BlogPostId = blogPostId;
        Text = text;
    }

    private Comment() { }

    public BlogPostId BlogPostId { get; private set; }
    public string Text { get; private set; }
}

public record CommentId(Guid Value)
{
    public static CommentId New() => new(Guid.NewGuid());
}
