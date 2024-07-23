using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Features.BlogPosts;
using BloggingPlatform.Domain.Messaging;

namespace BloggingPlatform.Application.BlogPosts;
public record GetPostsQuery() : IQuery<IEnumerable<GetPostsQueryResponse>>;
public record GetPostsQueryResponse(Guid Id, string Title, string Content, int Comments);

internal sealed class GetPostsQueryHandler(
    IBlogPostRepository _blogPostRepository)
    : IQueryHandler<GetPostsQuery, IEnumerable<GetPostsQueryResponse>>
{
    public async Task<Result<IEnumerable<GetPostsQueryResponse>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _blogPostRepository.GetAllAsync(cancellationToken);

        if (posts is null || !posts.Any())
            return Result.Failure<IEnumerable<GetPostsQueryResponse>>(BlogPostErrors.Empty);

        var response = posts.Select(s =>
        {
            return new GetPostsQueryResponse(s.Id.Value, s.Title, s.Content, s.Comments.Count());
        });

        return Result.Success(response);
    }
}
