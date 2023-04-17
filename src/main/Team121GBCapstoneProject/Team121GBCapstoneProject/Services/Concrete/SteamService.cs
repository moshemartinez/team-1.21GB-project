using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Team121GBCapstoneProject.Models.DTO;

namespace Team121GBCapstoneProject.Services.Concrete
{
    public class SteamService : IsteamService
    {
        private string BaseSource { get; }
        private string Token;

        public SteamService(string token)
        {
            Token = token;
            BaseSource =
                "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={0}&steamids={1}";
        }

        public async Task<string> GetJsonStringsFromEndpoint(string id)
        {
            string source = string.Format(BaseSource,Token, id);
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, source)
            {
                Headers =
                {
                    { HeaderNames.Accept, "application/json" }
                }
            };
            HttpClient httpClient = new HttpClient();
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
            string response = await GetJsonStringsFromEndpoint(id);
            Player deserialized = JsonConvert.DeserializeObject<Player>(response);
            SteamUser user = new SteamUser()
            {
                AvatarURL = deserialized.avatarmedium,
                ProfileURL = deserialized.profileurl,
                Username = deserialized.personaname
            };
            return user;
        }
    }
}
