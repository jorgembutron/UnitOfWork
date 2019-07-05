using Jb.Data.Client.Domain;
using System;
using System.Data;

namespace Jb.Data.Client.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IDbConnection DbConnection { get; set; }

        public void Add(Order order)
        {
            Console.WriteLine("Order Added");
        }
    }
}
