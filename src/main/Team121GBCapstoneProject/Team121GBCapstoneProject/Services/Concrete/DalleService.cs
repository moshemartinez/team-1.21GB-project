﻿using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.AspNetCore.Identity;
using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services.Abstract;
using System.Net;

namespace Team121GBCapstoneProject.Services.Concrete;

public class DalleService : IDalleService
{
    private readonly IOpenAIService _openAiService;

    public DalleService(IOpenAIService openAiService)
    {
        _openAiService = openAiService;
    }

    public async Task<string> GetImages(string prompt)
    {
        try
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = prompt,
                N = 1,
                Size = StaticValues.ImageStatics.Size.Size256,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url
            });

            string finalImage = null;
            foreach (var image in imageResult.Results)
            {
                finalImage = image.Url;
            }
            return finalImage;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    //public byte[] SetImageToProfilePicure(byte[] imageArray)
    //{
    //    if (imageArray == null) return Array.Empty<byte>();
    //    if (imageArray.Length == 0) return Array.Empty<byte>();
        
    //}

    public async Task<byte[]> TurnImageUrlIntoByteArray(string imageURL)
    {
        if (imageURL == null)
        {
            return null;
        }
        if (imageURL == "")
        {
            return null;
        }
        byte[] imageBytes;
        using (var client = new HttpClient())
        {
            using (var response = await client.GetAsync(imageURL))
            {
                imageBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }
        }
        return imageBytes;
    }
}