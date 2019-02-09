using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public sealed class PhotoModel
    {
        public readonly string Url;
        public readonly string Name;
        public readonly IReadOnlyCollection<Emotion> Emotions;

        public PhotoModel(string url, string name, IReadOnlyCollection<Emotion> emotions)
        {
            Url = url;
            Name = name;
            Emotions = emotions;
        }
    }
}