using System;

namespace CatelogVS.Dtos
{
    public record ItemDto
    {
        public Guid Id {get; init;}
        public string Name {get; init;}
        public decimal Price {get; init;}
        public DateTimeOffset CrateDate {get; init;}
    }
    // Dto หรือ Data transfer object เป็นการไม่ให้ user รู้หรือเข้าถึงข้อมูลที่เราใช้งานอยู่จริง 
    //โดยเราจะทำการเปลี่ยนแปลงข้อมูลที่ออกไปแสดงในหน้า swagger ui
}