namespace ChrisApp
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("ChrisDb");
            db.DropCollection("ChrisCollection");
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("ChrisCollection");

            BsonDocument document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                    {
                        { "x", 203 },
                        { "y", 102 }
                    }}
            };
            collection.InsertOne(document);

            IEnumerable<BsonDocument> documents = Enumerable.Range(0, 100).Select(i => new BsonDocument("counter", i));
            collection.InsertMany(documents);
            
            long count = collection.Count(new BsonDocument());
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
