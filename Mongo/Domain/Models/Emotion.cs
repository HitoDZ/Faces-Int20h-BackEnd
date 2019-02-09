using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public sealed class Emotion
    {
        [BsonIgnoreIfDefault] public decimal Sadness;
        [BsonIgnoreIfDefault] public decimal Neutral;
        [BsonIgnoreIfDefault] public decimal Disgust;
        [BsonIgnoreIfDefault] public decimal Anger;
        [BsonIgnoreIfDefault] public decimal Surprise;
        [BsonIgnoreIfDefault] public decimal Fear;
        [BsonIgnoreIfDefault] public decimal Happiness;
    }
}