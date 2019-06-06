using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new MongoClient();

            var db = client.GetDatabase("15net");
            var col = db.GetCollection<BsonDocument>("col01");

            var doc = new BsonDocument();

            col.InsertOne(doc);

        }
    }
}
