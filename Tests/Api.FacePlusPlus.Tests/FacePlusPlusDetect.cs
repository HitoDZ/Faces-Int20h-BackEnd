using System.Threading.Tasks;
using Xunit;

namespace Api.FacePlusPlus.Tests
{
    public class FacePlusPlusDetect
    {
        [Fact]
        public async Task FacePlusPlusDetect_Success()
        {
            var client = new FacePlusPlusClient(new FacePlusPlusClientOptions
            {
                ApiKey = "lchXf5hKsgWYCB9OEQ-GhuKQpIC9HdAy",
                ApiSecret = "CzRh0RUlt6zkEYNSY0uWYBFNBMBeOzjp"
            });

            var result = await client.GetEmotionsForPhotoAsync("https://lolzteam.net/data/avatars/l/621/621469.jpg");
            
            Assert.Null(result.ErrorMessage);
            Assert.Equal(1, result.Emotions.Count);
        }
    }
}