using Dapper;
using Jb.Dapper.Infrastructure.Abstractions;
using System.Data;

namespace Jb.Dapper.UnitTests
{
    public class MockRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public MockRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Test()
        {
            using(IDbConnection dbConnection = _dbConnectionFactory.DbConnection)
            {
                dbConnection.Query("xxx");
            }

            
            
        }
    }
}
