namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Utils;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(3, Utils.Add(1, 2));
        }

        [TestMethod]
        public void TestInsert()
        {
            // Arrange
            string dbName = "ChrisDb";
            string collectionName = "ChrisColletion";

            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(dbName);
            IMongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>(collectionName);
            long nbBefore = collection.Count(new BsonDocument());

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

            // Act
            Utils.Insert(dbName, collectionName, document);

            // Assert
            long nbAfter = collection.Count(new BsonDocument());
            Assert.AreEqual(nbBefore + 1, nbAfter);
        }
    }
}
