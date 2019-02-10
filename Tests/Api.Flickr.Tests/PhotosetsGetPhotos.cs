using System.Threading.Tasks;
using Xunit;

namespace Api.Flickr.Tests
{
    public class PhotosetsGetPhotos
    {
        [Fact]
        public async Task PhotosetsGetPhotos_Success()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                ApiKey = Defaults.API_KEY,
                UserId = "118310678@N03",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result.Photos);
            
            if (result.Photos.Count > 0)
                Assert.NotNull(result.Photos[0].Title);
        }
        
        [Fact]
        public async Task PhotosetsGetPhotos_Fail()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                // incorrect api_key
                ApiKey = "etAZ7DrhMq2yqTtWxTNWKbQnwpPmGxZn",
                UserId = "118310678@N03",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.NotNull(result.ErrorMessage);
        }
    }
}