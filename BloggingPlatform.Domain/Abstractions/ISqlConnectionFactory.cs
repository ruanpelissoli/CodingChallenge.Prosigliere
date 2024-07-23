using System.Data;

namespace BloggingPlatform.Domain.Abstractions;
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}

