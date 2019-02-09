using MongoDB.Driver;

namespace Domain.Persistance
{
    public sealed class MongoDbContext
    {
        public readonly IMongoCollection<DBPhotoModel> Photos;
        
        public MongoDbContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase("Int20h2019");

            Photos = db.GetCollection<DBPhotoModel>(nameof(Photos));
        }
    }
}