using System.Collections.Generic;

namespace Jb.Data.Client.Domain
{
    public class Order
    {
        public int Id { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
