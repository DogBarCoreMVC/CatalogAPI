using System;
using System.Collections.Generic;
using CatelogVS.Entities;

namespace CatelogVS.Repositories
{
   public interface InterfaceRepository//Create interface Method
    {
        IEnumerable<Item> GetItems();
        Item GetItemAsync(Guid id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}