using System.Collections.Generic;

namespace Api.FacePlusPlus.Models
{
    public sealed class FacePlusPlusDetectResult
    {
        internal FacePlusPlusDetectResult(string errorMessage) => ErrorMessage = errorMessage;

        internal FacePlusPlusDetectResult(List<FacePlusPlusEmotionModel> emotions) => Emotions = emotions;

        public bool IsOk => ErrorMessage == null;
        
        public readonly string ErrorMessage;
        public readonly List<FacePlusPlusEmotionModel> Emotions;
    }
}