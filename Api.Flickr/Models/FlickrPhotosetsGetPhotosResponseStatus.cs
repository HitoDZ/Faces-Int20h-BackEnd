namespace Api.Flickr.Models
{
    /// <summary>
    /// Statuses of response for photosets.getPhotos method
    /// </summary>
    public enum FlickrPhotosetsGetPhotosResponseStatus
    {
        Okay,
        PhotosetNotFound,
        UserNotFound,
        InvalidApiKey,
        ServiceCurrentlyUnavailable,
        AnotherError
    }
}