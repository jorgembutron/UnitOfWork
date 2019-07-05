using Jb.Dapper.Infrastructure.Abstractions;

namespace Jb.Dapper.Infrastructure
{
    public class DbConfiguration : IDbConfiguration
    {
        public string ConnectionString { get; set; }

        public DbConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
