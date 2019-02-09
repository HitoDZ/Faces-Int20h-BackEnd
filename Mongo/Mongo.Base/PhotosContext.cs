using Mongo.Base.Models;
using MongoDB.Driver;

namespace Mongo.Base
{
    public sealed class PhotosContext
    {
        public readonly IMongoCollection<PhotoModel> Photos;
        
        public PhotosContext(string connectionString)
        {
            var mongoClient = new MongoClient(connectionString);
            var db = mongoClient.GetDatabase(nameof(PhotosContext));

            Photos = db.GetCollection<PhotoModel>(nameof(Photos));
        }
    }
}