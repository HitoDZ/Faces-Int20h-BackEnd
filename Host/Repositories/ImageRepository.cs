using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Persistance;
using MongoDB.Driver;

namespace Host.Repositories
{
    public class ImageRepository
    {
        private readonly MongoDbContext _context;

        public ImageRepository(MongoDbContext context)
        {
            _context = context;
        }
       
        public Task<List<DBPhotoModel>> GetAsync(int? offset, int? count)
        {
            return _context.Photos.Find(FilterDefinition<DBPhotoModel>.Empty).Skip(offset).Limit(count).ToListAsync();
        }
    }
}
