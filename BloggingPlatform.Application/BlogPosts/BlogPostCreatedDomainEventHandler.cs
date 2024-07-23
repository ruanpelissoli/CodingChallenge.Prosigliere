using BloggingPlatform.Domain.Features.BlogPosts.Events;
using BloggingPlatform.Domain.Messaging;
using Microsoft.Extensions.Logging;

namespace BloggingPlatform.Application.BlogPosts;
internal sealed class BlogPostCreatedDomainEventHandler(
    ILogger<BlogPostCreatedDomainEventHandler> _logger)
    : IDomainEventHandler<BlogPostCreatedDomainEvent>
{
    public async Task Handle(BlogPostCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);

        // Process images attached to the post
        // Upload videos attached to the post
        // Notify users
        // etc etc

        _logger.LogInformation($"Blog post created: {notification.BlogPost.Id}");
    }
}
