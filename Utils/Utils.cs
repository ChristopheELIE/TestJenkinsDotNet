using MongoDB.Bson;
using MongoDB.Driver;

namespace Utils
{
    public static class Utils
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static void Insert(string dbName, string collectionName, BsonDocument document)
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(dbName);
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>(collectionName);
            collection.InsertOne(document);
        }
    }
}
