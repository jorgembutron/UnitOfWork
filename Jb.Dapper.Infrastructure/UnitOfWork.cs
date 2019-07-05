using Jb.Dapper.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Jb.Dapper.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDbConnectionFactory
    {
        private IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        public Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        private readonly string _connectionString;
        
        //public List<IRepository> _repositories = new List<IRepository>();

        public UnitOfWork(List<IRepository> repositories, IDbConfiguration dbConfiguration)
        {
            foreach (var repository in repositories)
                _repositories.Add(repository.GetType(), repository);

            if (dbConfiguration == null)
                throw new ArgumentNullException();

            _connectionString = dbConfiguration.ConnectionString;
        }

        public IRepository Repository<T>()
        {
            if (_repositories.ContainsKey(typeof(T)))
                return _repositories[typeof(T)] as IRepository;

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
