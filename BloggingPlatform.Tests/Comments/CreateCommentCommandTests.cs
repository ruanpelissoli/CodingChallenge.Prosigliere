using BloggingPlatform.Application.Comments;
using BloggingPlatform.Domain.Abstractions;
using BloggingPlatform.Domain.Comments;
using FluentAssertions;
using Moq;

namespace BloggingPlatform.Tests.Comments;

public class CreateCommentCommandTests
{
    private readonly Mock<ICommentRepository> _commentRepositoryMock;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    private CreateCommentCommandHandler? _sut;

    public CreateCommentCommandTests()
    {
        _commentRepositoryMock = new();
        _unitOfWorkMock = new();
    }

    [Fact]
    public async Task Should_CallRepository_When_CreateComment()
    {
        CreateCommentCommand command = new(Guid.NewGuid(), "My comment");

        _sut = new CreateCommentCommandHandler(_commentRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        _commentRepositoryMock.Verify(v => v.AddAsync(It.IsAny<Comment>()), Times.Once);
    }

    [Fact]
    public async Task Should_SaveChanges_When_CreateComment()
    {
        CreateCommentCommand command = new(Guid.NewGuid(), "My comment");

        _sut = new CreateCommentCommandHandler(_commentRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        _unitOfWorkMock.Verify(v => v.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Should_ReturnSuccessfulResponse_When_CreateComment()
    {
        CreateCommentCommand command = new(Guid.NewGuid(), "My comment");

        _sut = new CreateCommentCommandHandler(_commentRepositoryMock.Object, _unitOfWorkMock.Object);

        var result = await _sut.Handle(command, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
    }
}

public class CreateCommandCommandValidatorTest
{
    [Theory]
    [InlineData("5f36bd7c-5511-444f-88ab-1409fff50eff", "My comment", true)]
    [InlineData("00000000-0000-0000-0000-000000000000", "My comment", false)]
    [InlineData("5f36bd7c-5511-444f-88ab-1409fff50eff", null, false)]
    [InlineData("5f36bd7c-5511-444f-88ab-1409fff50eff", "", false)]
    public async Task Should_ValidateCommand_When_CreateComment(
        string blogPostId, string text, bool expectedResult)
    {
        CreateCommentCommandValidator validator = new();

        CreateCommentCommand command = new(Guid.Parse(blogPostId), text);

        var result = await validator.ValidateAsync(command);

        result.IsValid.Should().Be(expectedResult);
    }
}