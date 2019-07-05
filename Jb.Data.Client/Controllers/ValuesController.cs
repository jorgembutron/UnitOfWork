using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jb.Dapper.Infrastructure;
using Jb.Dapper.Infrastructure.Abstractions;
using Jb.Data.Client.Domain;
using Jb.Data.Client.Infrastructure;
using Jb.Data.Client.Infrastructure.Repositories;

namespace Jb.Data.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private string temp = "";
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var list = new List<IRepository>
            {
                new OrderRepository(), new ItemRepository()
            };

            var unitOfWork = new UnitOfWork(list, new DbConfiguration(temp));

            unitOfWork.Begin();

            IOrderRepository orderRepository = (IOrderRepository)unitOfWork.Repository<OrderRepository>();
            IItemRepository itemRepository = (IItemRepository)unitOfWork.Repository<ItemRepository>();

            orderRepository.Add(new Order());
            itemRepository.Add(new Item());

            unitOfWork.Commit();

            var db = unitOfWork.DbConnection;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
