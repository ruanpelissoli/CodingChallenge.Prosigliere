using BloggingPlatform.Application.Comments;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.API.Modules;

public class CommentsModule : CarterModule
{
    public CommentsModule() : base("api/posts/{blogPostId}/comments")
    {
        WithTags("Comments");
    }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (
            Guid blogPostId,
            [FromBody] CreateCommentRequest request, ISender sender, CancellationToken cancellation) =>
        {
            var command = new CreateCommentCommand(blogPostId, request.Text);

            var result = await sender.Send(command, cancellation);

            if (result.IsFailure)
                return Results.BadRequest(result);

            return Results.Ok(result);
        });
    }
}
