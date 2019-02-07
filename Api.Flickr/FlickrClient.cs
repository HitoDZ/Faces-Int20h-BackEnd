using System;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Flickr.Abstractions;
using Api.Flickr.Models;
using Newtonsoft.Json;

namespace Api.Flickr
{
    public sealed class FlickrClient : IFlickrClient, IDisposable
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.flickr.com/services/"),
            Timeout = TimeSpan.FromSeconds(10d)
        };

        private readonly FlickrClientOptions _options;

        public FlickrClient(FlickrClientOptions options)
        {
            _options = options;
        }

        public async Task<FlickrPhotosetsGetPhotosResponse> GetPhotosAsync()
        {
            try
            {
                var requestUri = $"rest/?method=flickr.photosets.getPhotos&api_key={_options.ApiKey}&photoset_id={_options.PhotosetId}&user_id={_options.UserId}&format=json&nojsoncallback=1";
                
                var response = await _client.GetStringAsync(requestUri);
                if (response == null)
                    return new FlickrPhotosetsGetPhotosResponse(0, "Response is null");

                dynamic json = JsonConvert.DeserializeObject(response);
                
                switch (json.stat)
                {
                    case "fail": return new FlickrPhotosetsGetPhotosResponse(json.code, json.message);
                    
                    case "ok":
                        return new FlickrPhotosetsGetPhotosResponse(json.photoset.photo);

                    default: return new FlickrPhotosetsGetPhotosResponse(0, "stat is incorrect");
                }
            }
            catch (Exception e)
            {
                return new FlickrPhotosetsGetPhotosResponse(0, e.ToString());
            }
        }

        public void Dispose() => _client.Dispose();
    }
}