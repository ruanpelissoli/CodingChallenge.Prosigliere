﻿namespace BloggingPlatform.Domain.Abstractions;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
