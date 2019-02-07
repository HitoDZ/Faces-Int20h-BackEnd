using System.Linq;
using System.Threading.Tasks;
using Api.Flickr.Models;
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
            
            Assert.Equal(FlickrPhotosetsGetPhotosResponseStatus.Okay, result.Status);
            Assert.NotNull(result.Photos.FirstOrDefault()?.Title);
        }

        [Fact]
        public async Task PhotosetsGetPhotos_PhotosetNotFound()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                ApiKey = "28968e00ebc529a31f878305c1df75c7",
                UserId = "118310678@N03",
                PhotosetId = "7215764132295454"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.Equal(FlickrPhotosetsGetPhotosResponseStatus.PhotosetNotFound, result.Status);
        }
        
        [Fact]
        public async Task PhotosetsGetPhotos_UserNotFound()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                ApiKey = "28968e00ebc529a31f878305c1df75c7",
                UserId = "999999999@N99",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.Equal(FlickrPhotosetsGetPhotosResponseStatus.UserNotFound, result.Status);
        }
        
        [Fact]
        public async Task PhotosetsGetPhotos_InvalidApiKey()
        {
            var client = new FlickrClient(new FlickrClientOptions
            {
                ApiKey = "28968e00ebc529a31f878305c1df75c8",
                UserId = "118310678@N03",
                PhotosetId = "72157641322954544"
            });

            var result = await client.GetPhotosAsync();
            
            Assert.Equal(FlickrPhotosetsGetPhotosResponseStatus.InvalidApiKey, result.Status);
        }
    }
}