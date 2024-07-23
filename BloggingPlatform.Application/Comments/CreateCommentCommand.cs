using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.Comments;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Messaging;
using FluentValidation;

namespace BloggingPlatform.Application.Comments;
public record CreateCommentRequest(string Text);
public record CreateCommentCommand(Guid BlogPostId, string Text) : ICommand<CreateCommentResponse>;
public record CreateCommentResponse(Guid Id, Guid BlogPostId, string Text);

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.BlogPostId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Text)
            .NotEmpty();
    }
}

internal sealed class CreateCommentCommandHandler(
     ICommentRepository _commentRepository,
     IUnitOfWork _unitOfWork)
    : ICommandHandler<CreateCommentCommand, CreateCommentResponse>
{
    public async Task<Result<CreateCommentResponse>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = Comment.Create(request.BlogPostId, request.Text);

        await _commentRepository.AddAsync(comment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success(new CreateCommentResponse(comment.Id.Value, comment.BlogPostId.Value, comment.Text));
    }
}