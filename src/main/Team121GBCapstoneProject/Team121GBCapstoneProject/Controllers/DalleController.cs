using Microsoft.AspNetCore.Mvc;

namespace Team121GBCapstoneProject.Controllers
{
    public class DalleController : Controller
    {
        public IActionResult GenerateImage()
        {
            return View();
        }
    }
}
