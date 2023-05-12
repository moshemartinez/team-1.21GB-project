using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Team121GBCapstoneProject.Services.Abstract;
using OpenAI.GPT3.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Team121GBCapstoneProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WhisperController : ControllerBase
{
    private readonly IWhisperService _whisperService;
    private readonly IOpenAIService _openAIService;

    public WhisperController(IWhisperService whisperService, IOpenAIService openAIService)
    {
        _whisperService = whisperService;
        _openAIService = openAIService;
    }
    [HttpPost("PostTextFromSpeech")]
    public async Task<ActionResult> Post(IFormFile file)
    {
        try
        {
            if (file == null)
                return BadRequest("No file selected");
            MemoryStream ms = new MemoryStream();
            await file.CopyToAsync(ms);
            byte[] fileBytes = ms.ToArray();            
            string resultText = await _whisperService.GetTextFromSpeech(fileBytes);
            return Ok(resultText);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

