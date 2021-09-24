using CatelogVS.Dtos;
using CatelogVS.Entities;

namespace CatelogVS
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {//ประกาศ static และ this เพื่อให้ class อื่นๆเรียกใช้งาน class ItemDto ได้
            return new ItemDto
            {
                CodeID = item.Id,
                Name = item.Name,
                Price = item.Price,
                CrateDate = item.CrateDate
            };
            //CodeID คือ properties ของ Class ItemDto (คือ class ที่ตั้งชื่อคือมาใหม่)
            //Id คือ properties ของ Class Item (คือ class เดิม)
        }
    }
}