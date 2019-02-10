using System;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Domain.Serializers
{
    public class CustomDecimalSerializer : SerializerBase<decimal>
    {
        private const decimal DECIMAL_PLACE = 10000m;

        public override decimal Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var dbData = context.Reader.ReadInt64();
            return Math.Round(dbData / DECIMAL_PLACE, 4);
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, decimal value)
        {
            var realValue = value;
            context.Writer.WriteInt64(Convert.ToInt32(realValue * DECIMAL_PLACE));
        }
    }
}