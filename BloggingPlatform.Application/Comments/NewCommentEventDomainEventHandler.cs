using BloggingPlatform.Domain.Features.Comments.Events;
using BloggingPlatform.Domain.Messaging;
using Microsoft.Extensions.Logging;

namespace BloggingPlatform.Application.Comments;
internal sealed class NewCommentEventDomainEventHandler(
    ILogger<NewCommentEventDomainEventHandler> _logger)
    : IDomainEventHandler<NewCommentEventDomainEvent>
{
    public async Task Handle(NewCommentEventDomainEvent notification, CancellationToken cancellationToken)
    {
        await Task.Delay(3000, cancellationToken);

        // Notify users about a new comment

        _logger.LogInformation($"New comment made: {notification.Comment.Text}");
    }
}
