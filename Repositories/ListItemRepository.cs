using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {//IEnumerable ใช้เพื่อแสดงข้อมูลที่มากๆ ใน list หรือ DataBase 
            return await Task.FromResult(items);//ส่งค่า item มาแสดง
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            //SingleOrDefault แสดงผลออกมาเฉพราะค่าที่ตรงกับ id เท่านั้น
            return await Task.FromResult(item);//ส่งค่า item มาแสดง
        }

        public async Task CreateItemAsync(Item item)//ส่วนนี้จะเป็น Method ที่เอาไว้ทำงานจริงๆ
        {//Create Implement Interface รับช่วงการทำงานต่อมาจาก Method CreateItem From Class InterfaceRepository
            items.Add(item);//POST
            await Task.CompletedTask;//ทำงานเสร็จแล้วไม่ส่งค่าอะไรกลับคืน
        }

        public async Task UpdateItemAsync(Item item)//Update
        {//Create Implement Interface 
            var index = items.FindIndex(UpdateItem => UpdateItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)//Delete
        {
            var index = items.FindIndex(DeleteItem => DeleteItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}