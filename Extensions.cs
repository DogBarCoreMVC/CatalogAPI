using CatelogVS.Dtos;
using CatelogVS.Entities;

namespace CatelogVS
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CrateDate = item.CrateDate
            };
        }
    }
}