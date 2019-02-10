using System.Collections.Generic;

namespace Api.Flickr.Models
{
    public sealed class FlickrPhotosetsGetPhotosResult
    {
        internal FlickrPhotosetsGetPhotosResult(string message)
        {
            ErrorMessage = message;
        }

        internal FlickrPhotosetsGetPhotosResult(List<FlickrPhotoModel> photos)
        {
            Photos = photos;
        }
        
        public bool IsOk => ErrorMessage == null;
        
        public readonly string ErrorMessage;
        public readonly List<FlickrPhotoModel> Photos;
    }
}