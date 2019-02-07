using Newtonsoft.Json;

namespace Api.FacePlusPlus.Models
{
    public sealed class FacePlusPlusEmotionResult
    {
        internal FacePlusPlusEmotionResult()
        {
        }
        
        [JsonProperty] public decimal Sadness { get; internal set; }
        [JsonProperty] public decimal Neutral { get; internal set; }
        [JsonProperty] public decimal Disgust { get; internal set; }
        [JsonProperty] public decimal Anger { get; internal set; }
        [JsonProperty] public decimal Surprise { get; internal set; }
        [JsonProperty] public decimal Fear { get; internal set; }
        [JsonProperty] public decimal Happiness { get; internal set; }
    }
}