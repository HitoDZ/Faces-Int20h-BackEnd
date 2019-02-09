using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Api.FacePlusPlus.Abstractions;
using Api.FacePlusPlus.Models;
using Newtonsoft.Json;

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

        public async Task<FacePlusPlusDetectResult> GetEmotionsForPhotoAsync(string photoUrl)
        {
            var requestUri = $"detect?api_key={_options.ApiKey}&api_secret={_options.ApiSecret}&image_url={photoUrl}&return_attributes=emotion";
            
            try
            {
                var response = await _client.PostAsync(requestUri, new StringContent(""));
                
                dynamic json = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

                string errorMessage = json.error_message;
                if (errorMessage != null)
                    return new FacePlusPlusDetectResult(errorMessage);

                var list = new List<FacePlusPlusEmotionModel>();
                foreach (var face in json.faces)
                    list.Add(face.attributes.emotion.ToObject<FacePlusPlusEmotionModel>());

                return new FacePlusPlusDetectResult(list);
            }
            catch (Exception e)
            {
                return new FacePlusPlusDetectResult(e.ToString());
            }
        }

        public void Dispose() => _client.Dispose();
    }
}