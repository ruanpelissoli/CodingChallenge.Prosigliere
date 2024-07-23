using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.BlogPosts.Events;
public sealed record BlogPostCreatedDomainEvent(BlogPostId BlogPostId) : IDomainEvent
{
}
