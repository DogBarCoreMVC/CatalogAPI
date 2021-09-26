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
        public MongoDbItemsRepository(IMongoClient mongoClient)//Dependency Injection
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);//ทำการอ้างอิงไปยัง Database
            itemCollection = database.GetCollection<Item>(CollectionsName);//ทำการอ้างอิง collections
        }
        public void CreateItem(Item item)
        {
            itemCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {//แสดงรายการทั้งหมดที่มี
            return itemCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}