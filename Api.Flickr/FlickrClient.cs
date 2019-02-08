using System;
using System.Collections.Generic;
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

        public FlickrClient(FlickrClientOptions options) => _options = options;

        public async Task<FlickrPhotosetsGetPhotosResult> GetPhotosAsync()
        {
            try
            {
                var requestUri = $"rest/?method=flickr.photosets.getPhotos&api_key={_options.ApiKey}&photoset_id={_options.PhotosetId}&user_id={_options.UserId}&format=json&nojsoncallback=1";
                
                var response = await _client.GetStringAsync(requestUri);
                if (string.IsNullOrEmpty(response))
                    return new FlickrPhotosetsGetPhotosResult("Response content is null or empty");

                dynamic json = JsonConvert.DeserializeObject(response);

                switch ((string) json.stat)
                {
                    case "fail": return new FlickrPhotosetsGetPhotosResult((string) json.message);
                    
                    case "ok": return new FlickrPhotosetsGetPhotosResult(json.photoset.photo
                        .ToObject<List<FlickrPhotoModel>>());

                    default: return new FlickrPhotosetsGetPhotosResult("stat is incorrect");
                }
            }
            catch (Exception e)
            {
                return new FlickrPhotosetsGetPhotosResult(e.ToString());
            }
        }

        public void Dispose() => _client.Dispose();
    }
}