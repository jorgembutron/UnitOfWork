using System.Runtime.InteropServices.ComTypes;

namespace Jb.Dapper.Infrastructure.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository Repository<T>();

        void Begin();

        void Commit();

        void Rollback();
    }
}
