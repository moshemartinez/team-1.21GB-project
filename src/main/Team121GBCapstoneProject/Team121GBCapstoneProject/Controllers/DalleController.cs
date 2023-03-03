using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using Team121GBCapstoneProject.Services;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DalleController : Controller
    {
        private readonly IDalleService _dalleService;

        public DalleController(IDalleService dalleService)
        {
            _dalleService = dalleService;
        }

        [HttpGet("GetImages")]
        public ActionResult<DalleVM> GetImages(string prompt)
        {
            DalleVM dalleVM = new DalleVM();
            if (prompt != null)
            {
                dalleVM.Prompt = prompt;
                dalleVM.Images = _dalleService.GetImages(prompt).Result;
            }
            else
            {
                throw new Exception("Prompt Invalid");
            }

            return Ok(dalleVM);
        }
    }
}
