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
            Assert.NotNull(result.Emotions);
            Assert.Single(result.Emotions);
        }
        
        [Fact]
        public async Task FacePlusPlusDetect_Fail()
        {
            var client = new FacePlusPlusClient(new FacePlusPlusClientOptions
            {
                ApiKey = "lchXf5hKsgWYCB9OEQ-GhuKQpIC9HdAy",
                ApiSecret = "CzRh0RUlt6zkEYNSY0uWYBFNBMBeOzjr"
            });

            var result = await client.GetEmotionsForPhotoAsync("https://lolzteam.net/data/avatars/l/621/621469.jpg");
            
            Assert.NotNull(result.ErrorMessage);
            Assert.Null(result.Emotions);
        }
    }
}