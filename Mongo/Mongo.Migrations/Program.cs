using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.FacePlusPlus;
using Api.Flickr;
using Api.Flickr.Models;
using Domain.Models;
using Domain.Persistance;
using MongoDB.Driver;

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

        private static readonly FacePlusPlusClientOptions _faceClientOptions = new FacePlusPlusClientOptions
        {
            ApiKey = Defaults.FACE_API_KEY,
            ApiSecret = Defaults.FACE_API_SECRET
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

            if (flickrResult.Photos.Count == 0)
            {
                Error("List of photos is empty");
                return;
            }

            var context = new MongoDbContext("mongodb://localhost");
            var i = 0;
            
            using (var faceClient = new FacePlusPlusClient(_faceClientOptions))
            foreach (var photo in flickrResult.Photos)
            {
                Console.Write("Processing - " + ++i);
                if (await context.Photos.Find(p => p.Name == photo.Title).AnyAsync())
                {
                    Info(" '" + photo.Title + " already Exist'");
                    continue;
                }

                var faceResult = await faceClient.GetEmotionsForPhotoAsync(photo.Photo('c'));

                if (!faceResult.IsOk)
                {
                    Error($"Error occurred while processing photo named {photo.Title}");
                    Error(faceResult.ErrorMessage);
                    return;
                }

                var emotions = new List<Emotion>();
                foreach (var emotion in faceResult.Emotions)
                    emotions.Add(new Emotion
                    {
                        Fear = emotion.Fear,
                        Anger = emotion.Anger,
                        Disgust = emotion.Disgust,
                        Neutral = emotion.Neutral,
                        Sadness = emotion.Sadness,
                        Surprise = emotion.Surprise,
                        Happiness = emotion.Happiness
                    });
                
                await context.Photos.InsertOneAsync(new DBPhotoModel
                {
                    Name = photo.Title,
                    Url = photo.Photo(),
                    Emotions = emotions
                });
                Info(" '" + photo.Title + " Added'");
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Info("All data ready! :)");
            Console.ForegroundColor = ConsoleColor.Gray;
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