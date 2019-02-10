using System;
using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
using Filter = MongoDB.Driver.FilterDefinition<Domain.Persistance.DBPhotoModel>;
using Builder = MongoDB.Driver.Builders<Domain.Persistance.DBPhotoModel>;

namespace Host.Extensions
{
    public static class FilterDefinitionExtensions
    {
        private static readonly CultureInfo _culture = new CultureInfo("en");
        
        public static void SetEmotions(this Dictionary<string, (string command, decimal value)> dict, string value)
        {
            if (value == null)
                return;
            
            foreach (var option in value.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                switch (option)
                {
                    case "sadness":
                    case "neutral":
                    case "disgust":
                    case "anger":
                    case "surprise":
                    case "fear":
                    case "happiness":
                        if (!dict.ContainsKey(option))
                            dict.Add(option, ("$gte", 55m));
                        continue;
                    
                    default: continue;
                }
            }
        }

        public static void TryAddEmotion(this Dictionary<string, (string, decimal)> dict, string fieldName,
            string command, decimal? percent)
        {
            if (!percent.HasValue)
                return;

            switch (command)
            {
                case "gte":
                case "lte":
                case "eq":
                case "lt":
                case "gt":
                    command = string.Concat("$", command);
                    break;
                
                default: return;
            }
            
            if (!dict.ContainsKey(fieldName))
                dict.Add(fieldName, (command, percent.Value));
        }

        private static string FirstToUpper(this string value) => char.ToUpper(value[0], _culture) + value.Substring(1);

        public static Filter GetPhotoFilter(this Dictionary<string, (string command, decimal value)> dict)
        {
            var filters = new List<Filter>();

            foreach (var (key, (command, percent)) in dict)
                filters.Add(new BsonDocument(string.Concat("Emotions.", key.FirstToUpper()),
                    new BsonDocument(command, Convert.ToInt64(percent * 10000m))));

            return filters.Count == 0 ? Filter.Empty : filters.Count == 1 ? filters[0] : Builder.Filter.And(filters);
        }
    }
}