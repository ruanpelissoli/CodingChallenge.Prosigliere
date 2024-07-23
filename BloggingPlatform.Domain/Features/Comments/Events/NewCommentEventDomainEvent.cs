using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Features.Comments;

namespace BloggingPlatform.Domain.Features.Comments.Events;

public sealed record NewCommentEventDomainEvent(Comment Comment) : IDomainEvent;
