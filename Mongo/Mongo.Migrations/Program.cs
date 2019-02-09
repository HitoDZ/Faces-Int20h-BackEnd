using System;
using System.Threading.Tasks;
using Api.Flickr;
using Api.Flickr.Models;

namespace Mongo.Migrations
{
    internal class Program
    {
        private static readonly FlickrClientOptions _flickrClientOptions = new FlickrClientOptions
        {
            ApiKey = Defaults.FLICKR_API_KEY,
            UserId = "118310678@N03",
            PhotosetId = "72157641322954544"
        };
        
        internal static async Task Main(string[] args)
        {
            FlickrPhotosetsGetPhotosResult flickrResult;
            
            using (var flickrClient = new FlickrClient(_flickrClientOptions))
                flickrResult = await flickrClient.GetPhotosAsync();

            if (!flickrResult.IsOk)
            {
                Error("An error occurred while getting the list of photos from Flickr API");
                Error(flickrResult.ErrorMessage);
                return;
            }
            
            Info("Successfully received the list of photos from Flickr API");
            Info($"Count of photos: {flickrResult.Photos.Count}");
        }

        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        private static void Info(string message)
        {
            Console.WriteLine(message);
        }
    }
}