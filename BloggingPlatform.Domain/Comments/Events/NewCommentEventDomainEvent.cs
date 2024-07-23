using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.Comments.Events;

public sealed record NewCommentEventDomainEvent(Comment Comment) : IDomainEvent;
