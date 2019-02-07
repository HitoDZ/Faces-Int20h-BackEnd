using System.Collections.Generic;

namespace Api.Flickr.Models
{
    public sealed class FlickrPhotosetsGetPhotosResponse
    {
        internal FlickrPhotosetsGetPhotosResponse(int errorCode, string message)
        {
            switch (errorCode)
            {
                case 1:
                    Status = FlickrPhotosetsGetPhotosResponseStatus.PhotosetNotFound;
                    break;
                
                case 2:
                    Status = FlickrPhotosetsGetPhotosResponseStatus.UserNotFound;
                    break;
                
                case 100:
                    Status = FlickrPhotosetsGetPhotosResponseStatus.InvalidApiKey;
                    break;
                
                case 105:
                    Status = FlickrPhotosetsGetPhotosResponseStatus.ServiceCurrentlyUnavailable;
                    break;
                
                default:
                    Status = FlickrPhotosetsGetPhotosResponseStatus.AnotherError;
                    break;
            }

            ErrorMessage = message;
        }

        internal FlickrPhotosetsGetPhotosResponse(IReadOnlyCollection<FlickrPhotoModel> photos)
        {
            Status = FlickrPhotosetsGetPhotosResponseStatus.Okay;
            Photos = photos;
        }

        /// <summary>
        /// Status of result
        /// </summary>
        public readonly FlickrPhotosetsGetPhotosResponseStatus Status;
        
        /// <summary>
        /// Error message. Is null if <see cref="Status"/> equals to <see cref="FlickrPhotosetsGetPhotosResponseStatus.Okay"/>
        /// </summary>
        public readonly string ErrorMessage;
        
        /// <summary>
        /// Read-only collection of photos. Is null if <see cref="Status"/> doesn't equal to <see cref="FlickrPhotosetsGetPhotosResponseStatus.Okay"/>
        /// </summary>
        public readonly IReadOnlyCollection<FlickrPhotoModel> Photos;
    }
}