using BloggingPlatform.Application.BlogPosts;
using Carter;
using Mapster;
using MediatR;

namespace BloggingPlatform.API.Modules;

public class BlogPostsModule : CarterModule
{
    public BlogPostsModule() : base("api/posts")
    {
        WithTags("BlogPosts");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateBlogPostRequest request, ISender sender, CancellationToken cancellation) =>
        {
            var command = request.Adapt<CreateBlogPostCommand>();

            var result = await sender.Send(command, cancellation);

            if (result.IsFailure)
                return Results.BadRequest(result);

            return Results.Ok(result);
        });
    }
}
