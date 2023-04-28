using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Services.Concrete;

public class ChatGptService : IChatGptService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IOpenAIService _openAiService;

    public ChatGptService(HttpClient httpClient, 
                          IConfiguration configuration,
                          IOpenAIService openAiService)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _openAiService = openAiService;
    }

    public Task<string> GetChatResponse(string prompt)
    {
        throw new NotImplementedException();
    }

    // public async Task<string> GetChatResponse(string prompt)
    // {
    //     var response = await _httpClient.PostAsJsonAsync(_configuration["ChatGptUrl"], new { prompt = prompt });
    //     var responseString = await response.Content.ReadAsStringAsync();
    //     return responseString;
    // }
}