using System.Data;

namespace Jb.Dapper.Infrastructure.Abstractions
{
    public interface IDbConnectionFactory
    {
        IDbConnection DbConnection { get; }
    }
}
