namespace Api.Flickr.Models
{
    /// <summary>
    /// Single flickr photo.
    /// </summary>
    public sealed class FlickrPhotoModel
    {
        internal FlickrPhotoModel(string id, string secret, string server, int farm, string title)
        {
            Title = title;

            _id = id;
            _secret = secret;
            _server = server;
            _farm = farm;
        }

        /// <summary>
        /// Title of photo.
        /// </summary>
        public readonly string Title;

        private readonly string _id;
        private readonly string _secret;
        private readonly string _server;
        private readonly int _farm;

        /// <summary>
        /// Returns an url of photo for specified size. Visit https://www.flickr.com/services/api/misc.urls.html for more info.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public string Photo(char size = 'q') => $"https://farm{_farm}.staticflickr.com/{_server}/{_id}_{_secret}_{size}.jpg";
    }
}