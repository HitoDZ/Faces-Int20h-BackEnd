using Newtonsoft.Json;

namespace Api.Flickr.Models
{
    /// <summary>
    /// Single flickr photo.
    /// </summary>
    public sealed class FlickrPhotoModel
    {
        internal FlickrPhotoModel()
        {
        }

        /// <summary>
        /// Title of photo.
        /// </summary>
        [JsonProperty] public string Title { get; internal set; }

        [JsonProperty] internal string Id { private get; set; }
        [JsonProperty] internal string Secret { private get; set; }
        [JsonProperty] internal string Server { private get; set; }
        [JsonProperty] internal int Farm { private get; set; }

        /// <summary>
        /// Returns an url of photo for specified size. Visit https://www.flickr.com/services/api/misc.urls.html for more info.
        /// </summary>
        /// <param name="size">Size identifier</param>
        /// <returns>Url to the photo</returns>
        public string Photo(char size = 'q') => $"https://farm{Farm}.staticflickr.com/{Server}/{Id}_{Secret}_{size}.jpg";
    }
}