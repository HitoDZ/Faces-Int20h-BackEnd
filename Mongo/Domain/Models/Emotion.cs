using Domain.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    public sealed class Emotion
    {
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Sadness;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Neutral;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Disgust;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Anger;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Surprise;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Fear;
        [BsonIgnoreIfDefault, BsonSerializer(typeof(CustomDecimalSerializer))] public decimal Happiness;
    }
}