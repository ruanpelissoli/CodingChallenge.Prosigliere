using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.BlogPosts;

namespace BloggingPlatform.Domain.Comments;

public interface ICommentRepository : IRepository<Comment, CommentId>
{
    Task<IEnumerable<Comment>> GetAllCommentsAsync(BlogPostId blogPostId);
}