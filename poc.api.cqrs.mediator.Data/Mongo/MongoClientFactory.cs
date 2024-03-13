using MongoDB.Driver;

namespace poc.api.cqrs.mediator.Infrastructure.Mongo
{
    public class MongoClientFactory
    {
        private readonly string _connectionString;

        public MongoClientFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IMongoClient CreateClient()
        {
            return new MongoClient(_connectionString);
        }
    }
}
