using BloggingPlatform.Application.Comments;
using Carter;
using Mapster;
using MediatR;

namespace BloggingPlatform.API.Modules;

public class CommentsModule : CarterModule
{
    public CommentsModule() : base("api/posts/{postId}/comments")
    {
        WithTags("Comments");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CreateCommentRequest request, ISender sender, CancellationToken cancellation) =>
        {
            var command = request.Adapt<CreateCommentCommand>();

            var result = await sender.Send(command, cancellation);

            if (result.IsFailure)
                return Results.BadRequest(result);

            return Results.Ok(result);
        });
    }
}
