using BloggingPlatform.Domain.Comments;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Messaging;
using FluentValidation;

namespace BloggingPlatform.Application.Comments;
public record CreateCommentRequest(Guid BlogPostId, string Text);
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

public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand, CreateCommentResponse>
{
    private readonly ICommentRepository _CommentRepository;

    public CreateCommentCommandHandler(ICommentRepository CommentRepository)
    {
        _CommentRepository = CommentRepository;
    }

    public Task<Result<CreateCommentResponse>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}