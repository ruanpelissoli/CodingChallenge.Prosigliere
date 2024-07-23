using BloggingPlatform.Domain.Common;
using MediatR;

namespace BloggingPlatform.Domain.Messaging;

public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{ }