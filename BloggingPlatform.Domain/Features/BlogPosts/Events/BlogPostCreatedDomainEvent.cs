using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Features.BlogPosts;

namespace BloggingPlatform.Domain.Features.BlogPosts.Events;
public sealed record BlogPostCreatedDomainEvent(BlogPost BlogPost) : IDomainEvent;
