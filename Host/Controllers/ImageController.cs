using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Persistance;
using Host.Constants;
using Host.Extensions;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Host.Controllers
{
    [Route(RouteConstants.Base)]
    public class ImageController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public ImageController(MongoDbContext context) => _context = context;

        [HttpGet(RouteConstants.Images)]
        public async Task<ActionResult<IReadOnlyCollection<DBPhotoModel>>> Get(
            [FromQuery] int? offset = null, [FromQuery] int? count = null,
            [FromQuery] decimal? sadness = null, [FromQuery] string sadness_comparison = null,
            [FromQuery] decimal? neutral = null, [FromQuery] string neutral_comparison = null,
            [FromQuery] decimal? disgust = null, [FromQuery] string disgust_comparison = null,
            [FromQuery] decimal? anger = null, [FromQuery] string anger_comparison = null,
            [FromQuery] decimal? fear = null, [FromQuery] string fear_comparison = null,
            [FromQuery] decimal? surprise = null, [FromQuery] string surprise_comparison = null,
            [FromQuery] decimal? happiness = null, [FromQuery] string happiness_comparison = null,
            [FromQuery] string emotions = null)
        {
            var dictionary = new Dictionary<string, (string command, decimal value)>();
            
            dictionary.TryAddEmotion("sadness", sadness_comparison, sadness);
            dictionary.TryAddEmotion("neutral", neutral_comparison, neutral);
            dictionary.TryAddEmotion("disgust", disgust_comparison, disgust);
            dictionary.TryAddEmotion("anger", anger_comparison, anger);
            dictionary.TryAddEmotion("fear", fear_comparison, fear);
            dictionary.TryAddEmotion("surprise", surprise_comparison, surprise);
            dictionary.TryAddEmotion("happiness", happiness_comparison, happiness);
            
            dictionary.SetEmotions(emotions);

            var filter = dictionary.GetPhotoFilter();
            return await _context.Photos.Find(filter).Skip(offset).Limit(count).ToListAsync();
        }
    }
}