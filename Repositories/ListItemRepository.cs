using System;
using System.Collections.Generic;
using System.Linq;
using CatelogVS.Entities;

namespace CatelogVS.Repositories
{

    public class ListItemRepository : InterfaceRepository
    {
        public readonly List<Item> items = new()
        {
            new Item { Id = Guid.NewGuid(), Name = "Rotito", Price = 25, CrateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Pomiro", Price = 15, CrateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Torito", Price = 65, CrateDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Hoya", Price = 85, CrateDate = DateTimeOffset.UtcNow },
        };
        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }
    }
}