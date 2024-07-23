using BloggingPlatform.Domain.Abstractions;

namespace BloggingPlatform.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
