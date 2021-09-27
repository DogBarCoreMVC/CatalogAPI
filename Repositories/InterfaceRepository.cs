using System;
using System.Collections.Generic;
using CatelogVS.Entities;

namespace CatelogVS.Repositories
{
   public interface InterfaceRepository//Create interface Method
    {
        IEnumerable<Item> GetItemsAsync();
        Item GetItemAsync(Guid id);
        void CreateItemAsync(Item item);
        void UpdateItemAsync(Item item);
        void DeleteItemAsync(Guid id);
    }
}