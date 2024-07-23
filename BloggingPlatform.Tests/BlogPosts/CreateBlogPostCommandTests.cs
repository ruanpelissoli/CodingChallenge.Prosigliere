using BloggingPlatform.Application.BlogPosts;
using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.Features.BlogPosts;
using FluentAssertions;
using Moq;

namespace BloggingPlatform.Tests.BlogPosts;
public class CreateBlogPostCommandTests
{
    private readonly Mock<IBlogPostRepository> _blogPostRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    private CreateBlogPostCommandHandler? _sut;

    public CreateBlogPostCommandTests()
    {
        _blogPostRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Should_CallRepository_When_CreateBlogPost()
    {
        CreateBlogPostCommand command = new("Title", "Content");

        _sut = new CreateBlogPostCommandHandler(_blogPostRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        _blogPostRepositoryMock.Verify(v => v.AddAsync(It.IsAny<BlogPost>()), Times.Once);
    }

    [Fact]
    public async Task Should_SaveChanges_When_CreateBlogPost()
    {
        CreateBlogPostCommand command = new("Title", "Content");

        _sut = new CreateBlogPostCommandHandler(_blogPostRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        _unitOfWorkMock.Verify(v => v.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Should_ReturnSuccessfulResponse_When_CreateBlogPost()
    {
        CreateBlogPostCommand command = new("Title", "Content");

        _sut = new CreateBlogPostCommandHandler(_blogPostRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}

public class CreateBlogCommandValidatorTest
{
    [Theory]
    [InlineData("Title", "Content", true)]
    [InlineData("", "Content", false)]
    [InlineData("Title", null, false)]
    public async Task Should_ValidateCommand_When_CreateBlogPost(
    string title, string content, bool expectedResult)
    {
        CreateBlogPostCommandValidator validator = new();

        CreateBlogPostCommand command = new(title, content);

        var result = await validator.ValidateAsync(command);

        result.IsValid.Should().Be(expectedResult);
    }
}