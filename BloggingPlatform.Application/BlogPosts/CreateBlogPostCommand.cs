using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.BlogPosts;
using BloggingPlatform.Domain.Common;
using BloggingPlatform.Domain.Messaging;
using FluentValidation;

namespace BloggingPlatform.Application.BlogPosts;

public record CreateBlogPostRequest(string Title, string Content);
public record CreateBlogPostCommand(string Title, string Content) : ICommand<CreateBlogPostResponse>;
public record CreateBlogPostResponse(Guid Id, string Title, string Content);

public class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
{
    public CreateBlogPostCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Content)
            .NotEmpty();
    }
}

public class CreateBlogPostCommandHandler : ICommandHandler<CreateBlogPostCommand, CreateBlogPostResponse>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IUnitOfWork unitOfWork)
    {
        _blogPostRepository = blogPostRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateBlogPostResponse>> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
    {
        var blogPost = BlogPost.Draft(request.Title, request.Content);

        await _blogPostRepository.AddAsync(blogPost);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(
            new CreateBlogPostResponse(blogPost.Id.Value, blogPost.Title, blogPost.Content));
    }
}
