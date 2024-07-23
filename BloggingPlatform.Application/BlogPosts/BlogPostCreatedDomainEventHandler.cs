using BloggingPlatform.Domain.BlogPosts.Events;
using BloggingPlatform.Domain.Messaging;

namespace BloggingPlatform.Application.BlogPosts;
internal sealed class BlogPostCreatedDomainEventHandler : IDomainEventHandler<BlogPostCreatedDomainEvent>
{
    public async Task Handle(BlogPostCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);

        Console.WriteLine($"Blog post created: {notification.BlogPostId}");
    }
}
