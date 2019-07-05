using Dapper;
using System.Collections.Generic;
using System.Data;

namespace Jb.Dapper.Infrastructure
{
    public class Readers
    {
        private readonly IDbConnection _dbConnection;
        private readonly IDbTransaction _transaction;

        public Readers(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Readers(IDbConnection dbConnection, IDbTransaction transaction)
        {
            _dbConnection = dbConnection;
            _transaction = transaction;
            
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true,
            int? commandTimeout = null, CommandType? commandType = null)
        {
            
            return _dbConnection.Query<T>(sql, param, _transaction, buffered, commandTimeout, commandType);
        }
    }
}
