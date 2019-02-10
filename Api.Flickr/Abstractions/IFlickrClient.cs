using System.Threading.Tasks;
using Api.Flickr.Models;

namespace Api.Flickr.Abstractions
{
    public interface IFlickrClient
    {
        Task<FlickrPhotosetsGetPhotosResult> GetPhotosAsync();
    }
}