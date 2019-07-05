using Jb.Dapper.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Jb.Dapper.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDbConnectionFactory
    {
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        public Dictionary<Type, IRepository> Repositories = new Dictionary<Type, IRepository>();
        private readonly string _connectionString;

        public UnitOfWork(List<IRepository> repositories, IDbConfiguration dbConfiguration)
        {
            _connectionString = dbConfiguration.ConnectionString;

            foreach (var repository in repositories)
            {
                repository.DbConnection = DbConnection;
                Repositories.Add(repository.GetType(), repository);
            }

            if (dbConfiguration == null)
                throw new ArgumentNullException();
        }

        public IRepository Repository<T>()
        {
            Type type = typeof(T);
            if (Repositories.ContainsKey(type))
                return Repositories[type];

            return null;
        }

        public void Begin()
        {
            _dbTransaction = _dbConnection.BeginTransaction();
        }

        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public IDbConnection DbConnection {
            get
            {
                _dbConnection = _dbConnection ?? (_dbConnection = new SqlConnection(_connectionString));

                if (_dbConnection.State != ConnectionState.Open)
                    _dbConnection.Open();

                return _dbConnection;
            }
        }
    }
}
