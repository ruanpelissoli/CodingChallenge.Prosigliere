using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.Features.BlogPosts;
using BloggingPlatform.Domain.Features.Comments.Events;

namespace BloggingPlatform.Domain.Features.Comments;
public class Comment : Entity<CommentId>
{
    public Comment(BlogPostId blogPostId, string text) : base(CommentId.New())
    {
        BlogPostId = blogPostId;
        Text = text;
    }

    protected Comment() { }

    public BlogPostId BlogPostId { get; private set; }
    public string Text { get; private set; }

    public static Comment Create(Guid blogPostId, string text)
    {
        var comment = new Comment(new BlogPostId(blogPostId), text);

        comment.RaiseDomainEvent(new NewCommentEventDomainEvent(comment));

        return comment;
    }
}

public record CommentId(Guid Value)
{
    public static CommentId New() => new(Guid.NewGuid());
}
