using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ProjectTemplate.WEB.Client.Application.Http
{
    public class ProjectTemplateHttpClient
    {
        readonly HttpClient _httpClient;

        private JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };

        public ProjectTemplateHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Get<T>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            await _ensureSuccessStatusCode(response);
            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseMessage);
            return result;
        }

        public async Task<T> Post<T>(string uri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, stringContent);

            await _ensureSuccessStatusCode(response);

            var responseMessage = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseMessage);
            return result;
        }


        public async Task Post(string uri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, stringContent);

            await _ensureSuccessStatusCode(response);
        }

        async Task _ensureSuccessStatusCode(HttpResponseMessage response)
        {            
            if (!response.IsSuccessStatusCode)
            {                    
                var responseMessage = await response.Content.ReadAsStringAsync();
                                        
                var jObj = JObject.Parse(responseMessage);
                jObj["Data"] = null; // because in MONO runtime we cant deserialize that property https://github.com/dotnet/aspnetcore/issues/10845

                var exception = JsonConvert.DeserializeObject<Exception>(jObj.ToString(), _settings);
                                
                throw exception;                            
            }            
        }        
    }
}
