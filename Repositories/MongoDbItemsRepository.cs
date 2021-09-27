using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using CatelogVS.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CatelogVS.Repositories
{
    public class MongoDbItemsRepository : InterfaceRepository
    {
        private const string databaseName = "catalog"; //const = ค่าคงที่
        private const string CollectionsName = "items";
        private readonly IMongoCollection<Item> itemCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        //create value filter (ใช้ในการตรวจสอบรายการใน collention)
        public MongoDbItemsRepository(IMongoClient mongoClient)//Dependency Injection
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);//ทำการอ้างอิงไปยัง Database
            itemCollection = database.GetCollection<Item>(CollectionsName);//ทำการอ้างอิง collections
        }
        public void CreateItemAsync(Item item)
        {
            itemCollection.InsertOne(item);
        }

        public void DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(deleItem => deleItem.Id, id);
            itemCollection.DeleteOne(filter);//ลบรายการที่ตรงกับ Id = id
        }

        public Item GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return itemCollection.Find(filter).SingleOrDefault();
            //SingleOrDefault ให้แสดงเฉพาะไอที่ตรงกับ Id = id ค่าที่ผ่านเข้าไปที่ parameter ...จะไม่แสดงรายการทั้งหมดออกมา
        }

        public IEnumerable<Item> GetItemsAsync()
        {//แสดงรายการทั้งหมดที่มี
            return itemCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItemAsync(Item item)
        {
            var filter = filterBuilder.Eq(updateItem => updateItem.Id, item.Id);
            itemCollection.ReplaceOne(filter,item);
            //ทำการแทนที่ item ด้วย filter ที่เป็น DataBase MongoDB
        }
    }
}