using System.Collections.Generic;
using Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Persistance
{
    public sealed class DBPhotoModel
    {
        public string Url;
        [BsonId] public string Name;
        public List<Emotion> Emotions;
    }
}