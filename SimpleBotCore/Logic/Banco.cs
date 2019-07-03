using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;

namespace SimpleBotCore.Logic
{
    public class Banco
    {
        private readonly MongoClient _mongoClient = null;

        private Banco()
        {
            _mongoClient = new MongoClient();
        }

        private static Banco _instance;

        public static Banco Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = new Banco();
                }

                return _instance;
            }
        }

        public void SalvarMensagem(SimpleMessage conversa)
        {
            var database = _mongoClient.GetDatabase("ChatBot");
            var collection = database.GetCollection<BsonDocument>("Conversas");
            collection.InsertOne(new BsonDocument
            {
                { "Id", conversa.Id },
                { "Text", conversa.Text },
                { "User", conversa.User },
            });
        }

        public int ContadorMsgs(string id)
        {
            var database = _mongoClient.GetDatabase("ChatBot");
            var collection = database.GetCollection<BsonDocument>("ContadorMsgs");

            var filter = new BsonDocument { { "ID", id } };

            var ret = collection.Find(filter).ToList();

            var cotador = 0;

            if (ret.Count > 0)
            {
                cotador = ret.FirstOrDefault()["Contador"].AsInt32;
            }

            collection.ReplaceOne(filter, new BsonDocument
            {
                { "ID", id },
                { "Contador", ++cotador }
            },
            new UpdateOptions { IsUpsert = true });

            return cotador;
        }

    }
}
