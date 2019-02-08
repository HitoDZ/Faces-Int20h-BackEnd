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
                ApiKey = Defaults.API_KEY,
                ApiSecret = Defaults.API_SECRET
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
                ApiKey = Defaults.API_KEY,
                // incorrect api_secret
                ApiSecret = "qffKT2SzsLtRJqwGHopiAqvUhoR3b44F"
            });

            var result = await client.GetEmotionsForPhotoAsync("https://lolzteam.net/data/avatars/l/621/621469.jpg");
            
            Assert.NotNull(result.ErrorMessage);
            Assert.Null(result.Emotions);
        }
    }
}