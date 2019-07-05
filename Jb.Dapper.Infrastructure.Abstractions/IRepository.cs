using System.Data;

namespace Jb.Dapper.Infrastructure.Abstractions
{
    public interface IRepository
    {
        IDbConnection DbConnection { get; set; }
    }
}
