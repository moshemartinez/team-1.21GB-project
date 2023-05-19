using Team121GBCapstoneProject.Services.Concrete;
using Team121GBCapstoneProject.Models;
using Microsoft.Extensions.Configuration;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using Moq;
using System.Net;

namespace Team121GBNUnitTest;
#nullable enable

public class WhisperServiceTests
{
    [Test]
    public void SaveByteArrayAsMp3_Success()
    {
        //* Arrange
        string key = "Fake key";
        OpenAI.GPT3.OpenAiOptions openAiOptions = new OpenAI.GPT3.OpenAiOptions()
        {
            ApiKey = key,
            BaseDomain = "https://fake.com"
        };
        IOpenAIService openAiService = new OpenAIService(openAiOptions);
        WhisperService whisperService = new WhisperService(openAiService);
        byte[] byteArray = new byte[1];
        string filePath = "/temp/audio.mp3";
        // ! Act
        whisperService.SaveByteArrayAsMp3(byteArray, filePath);
        byte[] file = File.ReadAllBytes($"/temp/audio.mp3");
        // ? Assert
        Assert.That(file, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void SaveByteArrayAsMp3_Failure()
    {
        //* Arrange
        string key = "Fake key";
        OpenAI.GPT3.OpenAiOptions openAiOptions = new OpenAI.GPT3.OpenAiOptions()
        {
            ApiKey = key,
            BaseDomain = "https://fake.com"
        };
        IOpenAIService openAiService = new OpenAIService(openAiOptions);
        WhisperService whisperService = new WhisperService(openAiService);
        byte[] byteArray = new byte[1];
        string filePath = "bad path";
        try
        {
            // ! Act
            whisperService.SaveByteArrayAsMp3(byteArray, filePath);
        }
        catch (Exception ex)
        {
            // ? Assert
            Assert.That(ex.Message, Is.EqualTo("The given path's format is not supported."));
        }
    }
}