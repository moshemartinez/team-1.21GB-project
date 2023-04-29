using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Areas.Identity.Data;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IGameRepository _gameRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, IGameRepository gameRepo, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _gameRepository = gameRepo;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        GameInfo gameList = new GameInfo();
        gameList.games = _gameRepository.GetTrendingGames(10);
        return View("Index", gameList);
    }

    public IActionResult Index1()
    {
        GameInfo gameList = new GameInfo();
        gameList.games = _gameRepository.GetTrendingGames(10);
        return View("Index1", gameList);
    }

    [Authorize]
    public IActionResult GenerateImage()
    {
        string authorizationId = _userManager.GetUserId(User);

        //int creditsCount = ?? 0;
        DalleVM dalleVM= new DalleVM();
        return View("GenerateImage", dalleVM);
    }

    [Authorize]
    public IActionResult ChatGpt () => View("ChatGpt");
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
