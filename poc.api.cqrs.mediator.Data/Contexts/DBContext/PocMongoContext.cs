using MongoDB.Driver;
using poc.api.cqrs.mediator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc.api.cqrs.mediator.Infrastructure.Contexts.DBContext
{
    public class PocMongoContext
    {
        private IMongoDatabase _database { get; }
        private IMongoClient _client { get; }

        public PocMongoContext()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017/"));

            settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);
            _client = mongoClient;
            _database = _client.GetDatabase("poc");
        }

        public IMongoCollection<Account> Account
        {
            get
            {
                return _database.GetCollection<Account>("account");
            }
        }
    }
}
