using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.AspNetCore.Identity;

namespace Team121GBCapstoneProject.Services;

class DalleService : IDalleService
{
    private readonly OpenAIService _openAiService;

    public DalleService(OpenAIService openAiService)
    {
        _openAiService = openAiService;
    }

    public async Task<List<string>> GetImages(string prompt)
    {
        try
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = prompt,
                N = 3,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url
            });

            List<string> images = new List<string>();
            foreach (var image in imageResult.Results)
            {
                images.Add(image.Url);
            }

            if (imageResult.Error == null)
            {
                throw new Exception("Error processing result");
            }

            return images;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}