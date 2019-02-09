using Mongo.Base.Models;
using MongoDB.Driver;

namespace Mongo.Base
{
    public sealed class MongoDbContext
    {
        public readonly IMongoCollection<PhotoModel> Photos;
        
        public MongoDbContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase(nameof(MongoDbContext));

            Photos = db.GetCollection<PhotoModel>(nameof(Photos));
        }
    }
}