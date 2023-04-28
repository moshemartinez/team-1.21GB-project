using System.Diagnostics;
using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Services.Concrete;
#nullable enable
public class ChatGptService : IChatGptService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IOpenAIService _openAiService;

    public ChatGptService(IHttpClientFactory httpClientFactory, 
                          IConfiguration configuration,
                          IOpenAIService openAiService)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _openAiService = openAiService;
    }
     public async Task<string> GetJsonStringFromEndpoint(string token, string uri, string clientId, string rawBody)
    {

        HttpClient httpClient = _httpClientFactory.CreateClient();

        // Add Headers
        // httpClient.BaseAddress = new Uri(uri);
        // httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        // httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        // httpClient.DefaultRequestHeaders.Add("Client-ID", clientId);

        // HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(rawBody));

        // // This is only a minimum version; make sure to cover all your bases here
        // if (response.IsSuccessStatusCode)
        // {
        //     // This is blocking; use ReadAsStreamAsync instead
        //     string responseText = await response.Content.ReadAsStringAsync();
        //     return responseText;
        // }
        // else
        // {
        //     throw new HttpRequestException();
        // }
        return "test";
    }
    
    public Task<string> GetChatResponse(string prompt)
    {
        try
        {
            
        }
        catch (HttpRequestException httpRequestException)
        {
            Debug.WriteLine(httpRequestException);
            return Task.FromResult("httpRequestException");
        }
        throw new NotImplementedException();
    }

    // public async Task<string> GetChatResponse(string prompt)
    // {
    //     var response = await _httpClient.PostAsJsonAsync(_configuration["ChatGptUrl"], new { prompt = prompt });
    //     var responseString = await response.Content.ReadAsStringAsync();
    //     return responseString;
    // }
}