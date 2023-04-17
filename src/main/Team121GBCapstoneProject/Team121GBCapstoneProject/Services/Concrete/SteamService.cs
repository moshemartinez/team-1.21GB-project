using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Team121GBCapstoneProject.Services.Concrete
{
    public class SteamService : IsteamService
    {
        private string BaseSource { get; }
        private IHttpClientFactory _httpClientFactory;

        public SteamService(IHttpClientFactory httpClientFactory)
        {
            BaseSource =
                "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=C53E34DF7E3C7A9ADC659511BD7B8EA6&steamids={0}";
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetJsonStringsFromEndpoint(string id)
        {
            string source = string.Format(BaseSource, id);
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, source)
            {
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                }
            };
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                string responseText = await response.Content.ReadAsStringAsync();
                return responseText;
            }
            else
            {
                throw new HttpRequestException();
            }
        }

        public async Task<SteamUser> GetSteamUser(string id)
        {
            string response =await GetJsonStringsFromEndpoint(id);
            SteamUser user = JsonConvert.DeserializeObject<SteamUser>(response);
            return user;
        }
    }
}
