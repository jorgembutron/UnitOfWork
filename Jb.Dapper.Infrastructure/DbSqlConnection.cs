using Jb.Dapper.Infrastructure.Abstractions;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Jb.Dapper.Infrastructure
{
    public class DbSqlConnection : IDbConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _dbConnection;

        public DbSqlConnection(IDbConfiguration dbConfiguration)
        {
            if (dbConfiguration == null)
                throw new ArgumentNullException();

            _connectionString = dbConfiguration.ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        public IDbConnection DbConnection
        {
            get
            {
                _dbConnection = _dbConnection ?? (_dbConnection = new SqlConnection(_connectionString));

                if (_dbConnection.State != ConnectionState.Open)
                    _dbConnection.Open();

                return _dbConnection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CloseConnection()
        {
            if (_dbConnection == null)
                return;

            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
        }
    }
}

