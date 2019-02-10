using System;
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
       
        public async Task<IReadOnlyCollection<DBPhotoModel>> GetAll()
        {
            return await _context.Photos.Find(FilterDefinition<DBPhotoModel>.Empty).ToListAsync();
        }
    }
}
