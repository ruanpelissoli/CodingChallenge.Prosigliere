using BloggingPlatform.Domain.Common;

namespace BloggingPlatform.Domain.BlogPosts;
public static class BlogPostErrors
{
    public static Error Empty = new(
        "BlogPost.Empty",
        "The blog posts were found");

    public static Error NotFound = new(
        "BlogPost.NotFound",
        "The blog post with the specified identifier was not found");
}
