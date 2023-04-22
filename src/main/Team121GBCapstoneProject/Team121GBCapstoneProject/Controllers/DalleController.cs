using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.Services.Abstract;

namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DalleController : Controller
    {
        private readonly IDalleService _dalleService;
        private readonly IReCaptchaV3Service _reCaptchaService;
        private readonly string _url = "https://www.google.com/recaptcha/api/siteverify";
        public DalleController(IDalleService dalleService, IReCaptchaV3Service reCaptchaService)
        {
            _dalleService = dalleService;
            _reCaptchaService = reCaptchaService;
        }

        [HttpGet("GetImages")]
        public ActionResult<string> GetImages(string prompt, string gRecaptchaResponse)
        {
            try
            {
                //Debug.Assert(gRecaptchaResponse != null);
                if (gRecaptchaResponse == null) return BadRequest();
                if (!_reCaptchaService.IsValid(gRecaptchaResponse, _url).Result) return BadRequest();
                string image = "";
                if (prompt != null)
                {
                    image = _dalleService.GetImages(prompt).Result;
                }
                return Ok(image);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [HttpPost("SetImageToProfilePicure")]
        public async Task<string> SetImageToProfilePicure(string imageURL)
        {
            try
            {
                if (imageURL != null)
                {
                    return await _dalleService.SetImageToProfilePicure(imageURL);
                }
                return "";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return "";
            }
        }
    }
}

            //DalleVM dalleVM = new DalleVM();
            //if (prompt != null)
            //{
            //    dalleVM.Prompt = prompt;
            //    dalleVM.ImageURL = _dalleService.GetImages(prompt).Result;
            //}
            //else
            //{
            //    throw new Exception("Prompt Invalid");
            //}

            //return Ok(dalleVM);