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
        {//IEnumerable ใช้เพื่อแสดงข้อมูลที่มากๆ ใน list หรือ DataBase 
            return items;
        }
        public Item GetItemAsync(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
            //SingleOrDefault แสดงผลออกมาเฉพราะค่าที่ตรงกับ id เท่านั้น
        }

        public void CreateItem(Item item)//ส่วนนี้จะเป็น Method ที่เอาไว้ทำงานจริงๆ
        {//Create Implement Interface รับช่วงการทำงานต่อมาจาก Method CreateItem From Class InterfaceRepository
            items.Add(item);//POST
        }

        public void UpdateItem(Item item)//Update
        {//Create Implement Interface 
            var index = items.FindIndex(UpdateItem => UpdateItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)//Delete
        {
            var index = items.FindIndex(DeleteItem => DeleteItem.Id == id);
            items.RemoveAt(index);
        }
    }
}