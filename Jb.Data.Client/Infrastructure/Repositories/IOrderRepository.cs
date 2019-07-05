using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jb.Dapper.Infrastructure.Abstractions;
using Jb.Data.Client.Domain;

namespace Jb.Data.Client.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository
    {
        void Add(Order order);
    }
}
