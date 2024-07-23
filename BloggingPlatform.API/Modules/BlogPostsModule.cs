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
        app.MapGet("/", async (ISender sender, CancellationToken cancellation) =>
        {
            var result = await sender.Send(new GetPostsQuery(), cancellation);

            if (result.IsFailure)
                return Results.NotFound(result);

            return Results.Ok(result);
        });

        app.MapGet("/{id}", async (Guid id, ISender sender, CancellationToken cancellation) =>
        {
            var result = await sender.Send(new GetPostByIdQuery(id), cancellation);

            if (result.IsFailure)
                return Results.NotFound(result);

            return Results.Ok(result);
        });

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
