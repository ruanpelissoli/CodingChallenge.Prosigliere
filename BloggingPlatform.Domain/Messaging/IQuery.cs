using BloggingPlatform.Domain.Common;
using MediatR;

namespace BloggingPlatform.Domain.Messaging;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{ }

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
where TQuery : IQuery<TResponse>
{ }
