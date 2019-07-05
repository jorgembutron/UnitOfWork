using Jb.Data.Client.Domain;
using System;
using System.Data;

namespace Jb.Data.Client.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public IDbConnection DbConnection { get; set; }

        public void Add(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
