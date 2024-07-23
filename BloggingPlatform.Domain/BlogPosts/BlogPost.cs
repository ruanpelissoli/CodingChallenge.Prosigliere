using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.BlogPosts.Events;
using BloggingPlatform.Domain.Comments;

namespace BloggingPlatform.Domain.BlogPosts;

public class BlogPost : Entity<BlogPostId>
{
    public BlogPost(string title, string content, EBlogStatus status) : base(BlogPostId.New())
    {
        Title = title;
        Content = content;
        Status = status;
    }

    protected BlogPost() { }

    public string Title { get; private set; }
    public string Content { get; private set; }
    public EBlogStatus Status { get; private set; }
    public ICollection<Comment> Comments { get; private set; } = [];

    public static BlogPost Draft(string title, string content)
    {
        var blogPost = new BlogPost(title, content, EBlogStatus.Draft);

        blogPost.RaiseDomainEvent(new BlogPostCreatedDomainEvent(blogPost));

        return blogPost;
    }
}

public record BlogPostId(Guid Value)
{
    public static BlogPostId New() => new(Guid.NewGuid());
}
