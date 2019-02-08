using System.Collections.Generic;

namespace Api.Flickr.Models
{
    public sealed class FlickrPhotosetsGetPhotosResponse
    {
        internal FlickrPhotosetsGetPhotosResponse(string message)
        {
            ErrorMessage = message;
        }

        internal FlickrPhotosetsGetPhotosResponse(List<FlickrPhotoModel> photos)
        {
            Photos = photos;
        }
        
        public bool IsOk => ErrorMessage == null;
        
        public readonly string ErrorMessage;
        public readonly List<FlickrPhotoModel> Photos;
    }
}