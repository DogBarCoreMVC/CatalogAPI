using System.Net.Mime;
using System;
namespace CatelogVS.Entities
{
    public record Item
    // record type คือใช้สำหรับ class ที่มีการบันทีกค่าที่ไม่มีการเปลี่ยนแปลง
    {
        public Guid Id { get; init; }//Guid เป็น DataType ที่นิยมเอามาใช้งานในข้อมูลที่เกี่ยวกับ Id หรือ Primary key เพราะ Guid จะให้ข้อมูลที่ไม่ซ้ำกันตั้งแต่ a-f และ 0-9 สลับกันไป 
        public string Name {get; init;}
        public decimal Price {get; init;}
        public DateTimeOffset CrateDate {get; init;}
    }
}