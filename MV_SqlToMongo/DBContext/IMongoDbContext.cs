using MongoDB.Driver;

namespace MV_SqlToMongo.DBContext
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName, string databaseName);
        IMongoDatabase GetDatabase(string databaseName);
    }
}
