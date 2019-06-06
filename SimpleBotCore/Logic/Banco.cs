using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Logic
{
    public class Banco
    {
        MongoClient _mc = null;


        private Banco()
        {
            _mc = new MongoClient();
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
            var db = _mc.GetDatabase("ChatBot");
            var col = db.GetCollection<BsonDocument>("Conversas");
            col.InsertOne(new BsonDocument
            {
                { "Id", conversa.Id },
                { "Text", conversa.Text },
                { "User", conversa.User },
            });
        }

        public int ContadorMsgs(string id)
        {
            var db = _mc.GetDatabase("ChatBot");
            var col = db.GetCollection<BsonDocument>("ContadorMsgs");

            var filter = new BsonDocument { { "ID", id } };

            var ret = col.Find(filter).ToList();

            var cotador = 0;

            if (ret.Count > 0)
            {
                cotador = ret.FirstOrDefault()["Contador"].AsInt32;
            }

            col.ReplaceOne(filter,
                new BsonDocument
                {
                        { "ID", id },
                        { "Contador", ++cotador }
                },
                new UpdateOptions { IsUpsert = true });

            return cotador;
        }

    }
}
