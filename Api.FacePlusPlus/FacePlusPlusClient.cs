using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.FacePlusPlus.Abstractions;
using Api.FacePlusPlus.Models;

namespace Api.FacePlusPlus
{
    public sealed class FacePlusPlusClient : IFacePlusPlusClient, IDisposable
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://api-us.faceplusplus.com/facepp/v3/"),
            Timeout = TimeSpan.FromSeconds(10d)
        };

        private readonly FacePlusPlusClientOptions _options;

        public FacePlusPlusClient(FacePlusPlusClientOptions options) => _options = options;

        public async Task<FacePlusPlusDetectResult> GetEmotionsForPhoto(string photoUrl)
        {
            var requestUri = $"detect?api_key={_options.ApiKey}&api_secret={_options.ApiSecret}&image_url={photoUrl}&return_attributes=emotion";
            var response = await _client.GetAsync(requestUri);

            return null;
        }

        public void Dispose() => _client.Dispose();
    }
}