using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Base.Models
{
    public sealed class DBPhotoModel
    {
        public string Url;
        [BsonId] public string Name;
        public List<Emotion> Emotions;
    }
}