using System;
using System.Collections.Generic;
using CatelogVS.Entities;

namespace CatelogVS.Repositories
{
   public interface InterfaceRepository//Create interface Method
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}