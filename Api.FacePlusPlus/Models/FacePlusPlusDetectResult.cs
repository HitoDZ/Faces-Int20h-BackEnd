using System.Collections.Generic;

namespace Api.FacePlusPlus.Models
{
    public sealed class FacePlusPlusDetectResult
    {
        internal FacePlusPlusDetectResult(string errorMessage) => ErrorMessage = errorMessage;

        internal FacePlusPlusDetectResult(List<FacePlusPlusEmotionResult> emotions) => Emotions = emotions;

        public bool IsOk => ErrorMessage == null;
        
        public readonly string ErrorMessage;
        public readonly List<FacePlusPlusEmotionResult> Emotions;
    }
}