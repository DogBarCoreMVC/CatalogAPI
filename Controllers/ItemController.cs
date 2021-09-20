using System.Linq;
using System;
using System.Collections.Generic;
using CatelogVS.Entities;
using CatelogVS.Repositories;
using Microsoft.AspNetCore.Mvc;
using CatelogVS.Dtos;

namespace CatelogVS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly InterfaceRepository repositoty;
        public ItemController(InterfaceRepository repository)//Dependency Injection
        {
            this.repositoty = repository;
        }

        // Route https://localhost:5001/Item
        [HttpGet] // Method HttpGet จะตอบกลับไปจากการเรียกใช้งานของผู้ใช้ โดยจะแสดงข้อมูลใน Method GetItems()
        
        public IEnumerable<ItemDto> GetItems()
        {
            var Items = repositoty.GetItems().Select(item => item.AsDto());

            return Items;
        }

        // https://localhost:5001/Item/{id}
        [HttpGet("{id}")] //Method HttpGet(id) จะตอบกลับไปจากการเรียกใช้งานของผู้ใช้ โดยให้ผู้ใช้ใส่ค่า id ที่ต้องการค้นหา โดยจะแสดงข้อมูลใน Method GetItem(Guid id)
        public ActionResult<ItemDto> GetItem(Guid id)//รับข้อมูลจากผู้ใช้คือ id //ActionResult จะสามารถส่งค่าได้มากกว่า 1 ประเภท
        {
            var item = repositoty.GetItem(id);
            if(item is null)//ค่าว่าง
            {
                return NotFound();//Return Status 404
            }
            return item.AsDto();
            //แสดงผลที่ค้นหา(กรณีเจอไอดีที่ค้นหา)
        }
    }
}