using System.Linq;
using System;
using System.Collections.Generic;
using CatelogVS.Entities;
using CatelogVS.Repositories;
using Microsoft.AspNetCore.Mvc;
using CatelogVS.Dtos;
using System.Threading.Tasks;

namespace CatelogVS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly InterfaceRepository repository;
        public ItemController(InterfaceRepository repository)//Dependency Injection
        {
            this.repository = repository;
        }

        // Route https://localhost:5001/Item
        [HttpGet] //Method HttpGet จะตอบกลับไปจากการเรียกใช้งานของผู้ใช้ โดยจะแสดงข้อมูลใน Method GetItems()
        
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {//IEnumerable ใช้เพื่อแสดงข้อมูลที่มากๆ ใน list หรือ DataBase
            var Items = (await repository.GetItemsAsync())
                        .Select(item => item.AsDto());
            return Items;
        }

        //https://localhost:5001/Item/{id}
        [HttpGet("{id}")]//Method HttpGet(id) จะตอบกลับไปจากการเรียกใช้งานของผู้ใช้ โดยให้ผู้ใช้ใส่ค่า id ที่ต้องการค้นหา โดยจะแสดงข้อมูลใน Method GetItem(Guid id)
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {//รับข้อมูลจากผู้ใช้คือ id //ActionResult จะสามารถส่งค่าได้มากกว่า 1 ประเภท
            var item = await repository.GetItemAsync(id);
            if(item is null)//null ค่าว่าง
            {
                return NotFound();//Return Status 404
            }
            return item.AsDto();
            //แสดงผลที่ค้นหา(กรณีเจอไอดีที่ค้นหา)
        }

        // POST /Item
        //location: https://localhost:5001/Item/db97e1ff-3030-44ca-9348-3f7e424ec6ba (Response)
        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto createItemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),//service set
                Name = createItemDto.Name,//user set
                Price = createItemDto.Price,//user set
                CrateDate = DateTimeOffset.UtcNow//service set
            };

            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new {id = item.Id}, item.AsDto());
        }

        // PUT / Item / {id}
        //https://localhost:5001/Item/6618a0b2-2e88-4903-915d-db83ba427b3b (Response)
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var DataItem = await repository.GetItemAsync(id);

            if (DataItem is null)
            {
                return NotFound();
            }

            Item Update = DataItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(Update);

            return NoContent();
        }

        //DELETE / Item / {id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var DelItem = await repository.GetItemAsync(id);

            if (DelItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            
            return NoContent();
        }
    }
}