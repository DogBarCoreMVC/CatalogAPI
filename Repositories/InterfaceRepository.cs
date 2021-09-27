using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using CatelogVS.Entities;

namespace CatelogVS.Repositories
{
   public interface InterfaceRepository//Create interface Method
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid id);
    }
}