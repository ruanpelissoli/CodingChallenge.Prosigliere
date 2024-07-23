using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.BlogPosts.Events;
public sealed record BlogPostCreatedDomainEvent(BlogPost BlogPost) : IDomainEvent;
