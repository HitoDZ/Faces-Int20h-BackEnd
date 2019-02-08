using System.Linq;
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
                ApiKey = "28968e00ebc529a31f878305c1df75c7",
                UserId = "118310678@N03",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.Null(result.ErrorMessage);
            Assert.NotNull(result.Photos.FirstOrDefault()?.Title);
        }
        
        [Fact]
        public async Task PhotosetsGetPhotos_Fail()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                ApiKey = "28968e00ebc529a31f878305c1df75c8",
                UserId = "118310678@N03",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.NotNull(result.ErrorMessage);
        }
    }
}