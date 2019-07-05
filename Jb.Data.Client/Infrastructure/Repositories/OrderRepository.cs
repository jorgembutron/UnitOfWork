using Jb.Data.Client.Domain;
using System;
using System.Data;
using Dapper;

namespace Jb.Data.Client.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IDbConnection DbConnection { get; set; }

        public void Add(Order order)
        {
            var result =  DbConnection.Query("select * from dd_configuracion_canal_comunicacion where c_canal_comunicacion = 1");
            Console.WriteLine("Order Added");
        }
    }
}
