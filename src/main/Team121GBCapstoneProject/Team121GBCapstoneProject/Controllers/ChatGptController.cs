using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using Team121GBCapstoneProject.Areas.Identity.Data;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatGptController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IChatGptService _chatGptService;

    public ChatGptController(UserManager<ApplicationUser> userManager,
                                         IChatGptService chatGptService)
    {
        _userManager = userManager;
        _chatGptService = chatGptService;
    }

    [HttpGet("GetChatResponse")]
    public async Task<ActionResult<string>> GetChatResponse(string prompt)
    {
        try
        {
            string response = "Bleh";
            // Thread.Sleep(10000);
            // if (String.IsNullOrEmpty(prompt) is false)
            // {
            //     response = await _chatGptService.GetChatResponse(prompt);
            // }
            return Ok(response);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}