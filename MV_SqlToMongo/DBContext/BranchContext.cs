using MongoDB.Driver;

namespace MV_SqlToMongo.DBContext
{
    public class BranchContext : IMongoDbContext
    {
        IMongoClient _client;
        IMongoDatabase _database;
        public BranchContext(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName, string databaseName)
        {
            var db = GetDatabase(databaseName);
            IMongoCollection<T> collect = db.GetCollection<T>(collectionName);
            if(collect == null)
            {
                db.CreateCollection(collectionName);
                collect = db.GetCollection<T>(collectionName);
            }
            return collect;
        }
        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _client.GetDatabase(databaseName);
        }
    }
}
