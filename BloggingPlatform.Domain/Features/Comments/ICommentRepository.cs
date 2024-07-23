using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.Features.BlogPosts;

namespace BloggingPlatform.Domain.Features.Comments;

public interface ICommentRepository : IRepository<Comment, CommentId>
{
    Task<IEnumerable<Comment>> GetAllCommentsAsync(BlogPostId blogPostId);
}