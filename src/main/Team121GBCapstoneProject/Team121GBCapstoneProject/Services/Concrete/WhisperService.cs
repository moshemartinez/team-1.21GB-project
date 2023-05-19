using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services.Abstract;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.Extensions;
using static OpenAI.GPT3.ObjectModels.Models;
using System.Diagnostics;
using System.IO;

namespace Team121GBCapstoneProject.Services.Concrete;

public class WhisperService : IWhisperService
{
    private readonly IOpenAIService _openAIService;
    public WhisperService(IOpenAIService openAIService) => _openAIService = openAIService;


    public void SaveByteArrayAsMp3(byte[] byteArray, string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                fs.Write(byteArray, 0, byteArray.Length);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            throw new Exception(ex.Message);
        }

    }

    public async Task<string> GetTextFromSpeech(byte[] audioMp3)
    {

        if (audioMp3 is null or { Length: 0 }) throw new ArgumentNullException(nameof(audioMp3), "The audioMp3 byte array is null or empty.");

        string fileName = "audio.mp3";
        SaveByteArrayAsMp3(audioMp3, "temp/audio.mp3");
        byte[] file = await File.ReadAllBytesAsync($"temp/{fileName}");
        MemoryStream ms = new MemoryStream(file);
        var audioResult = await _openAIService.Audio.CreateTranscription(new AudioCreateTranscriptionRequest()
        {
            FileName = fileName,
            File = file,
            Model = WhisperV1,
            ResponseFormat = StaticValues.AudioStatics.ResponseFormat.VerboseJson
        });
        if (audioResult.Successful)
        {
            Debug.WriteLine(string.Join("\n", audioResult.Text));
            return audioResult.Text;
        }
        else
        {
            if (audioResult.Error == null)
            {
                throw new Exception("Unknown Error returned from OpenAI API.");
            }
            Debug.WriteLine($"{audioResult.Error.Code}: {audioResult.Error.Message}");
            throw new Exception(audioResult.Error.Message);
        }
    }
}
