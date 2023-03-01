using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.DAL.Abstract;

namespace Team121GBCapstoneProjects.Controllers;

public class GamesListsController : Controller
{
    private readonly ILogger<GamesListsController> _logger;
    private IGameRepository _gameRepository;

    public GamesListsController(ILogger<GamesListsController> logger, IGameRepository gameRepo)
    {
        _logger = logger;
        _gameRepository = gameRepo;
    }

    public IActionResult Index()
    {
        GameInfo gameList = new GameInfo();
        gameList.games = _gameRepository.GetTrendingGames(10);
        return View("Index", gameList);
    }
}