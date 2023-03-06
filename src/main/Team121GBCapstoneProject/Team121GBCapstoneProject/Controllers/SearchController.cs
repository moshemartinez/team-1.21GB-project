using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.Controllers;

public class SearchController : Controller
{
    private readonly ILogger<SearchController> _logger;
    //private IGameRepository _gameRepository;

    public SearchController(ILogger<SearchController> logger)
    {
        _logger = logger;
        //_gameRepository = gameRepo;
    }

    public IActionResult Results(IEnumerable<IgdbGame> gameSearchResults)
    {

        return View("SearchResults", gameSearchResults);
    }

}

