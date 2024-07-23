using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Messaging;

namespace BloggingPlatform.Application.BlogPosts;
public record GetPostByIdQuery(Guid Id) : IQuery<GetPostByIdResponse>;
public record GetPostByIdResponse(Guid Id, string Title, string Content, IEnumerable<CommentResponse> Comments);
public record CommentResponse(string Text);

internal sealed class GetPostByIdQueryHandler(
    IBlogPostRepository _blogPostRepository)
    : IQueryHandler<GetPostByIdQuery, GetPostByIdResponse>
{
    public async Task<Result<GetPostByIdResponse>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _blogPostRepository.GetByIdAsync(new BlogPostId(request.Id), cancellationToken);

        if (post is null)
            return Result.Failure<GetPostByIdResponse>(BlogPostErrors.NotFound);

        return Result.Success(new GetPostByIdResponse(
            post.Id.Value,
            post.Title,
            post.Content,
            post.Comments.Select(
                s => new CommentResponse(s.Text)))
            );
    }
}