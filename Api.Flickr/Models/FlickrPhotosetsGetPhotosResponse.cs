using System.Collections.Generic;

namespace Api.Flickr.Models
{
    public sealed class FlickrPhotosetsGetPhotosResponse
    {
        internal FlickrPhotosetsGetPhotosResponse(string message)
        {
            ErrorMessage = message;
        }

        internal FlickrPhotosetsGetPhotosResponse(IReadOnlyCollection<FlickrPhotoModel> photos)
        {
            Photos = photos;
        }
        
        public bool IsOk => ErrorMessage == null;
        
        public readonly string ErrorMessage;
        
        /// <summary>
        /// Read-only collection of photos. Is null if <see cref="Status"/> doesn't equal to <see cref="FlickrPhotosetsGetPhotosResponseStatus.Okay"/>
        /// </summary>
        public readonly IReadOnlyCollection<FlickrPhotoModel> Photos;
    }
}