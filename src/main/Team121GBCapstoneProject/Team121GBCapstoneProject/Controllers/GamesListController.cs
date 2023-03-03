using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Team121GBCapstoneProject.Areas.Identity.Data;

namespace Team121GBCapstoneProjects.Controllers;

public class GamesListsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<GamesListsController> _logger;
    private IPersonRepository _personRepository;
    public GamesListsController(UserManager<ApplicationUser> userManager, ILogger<GamesListsController> logger, IPersonRepository personRepository)
    {
        _userManager = userManager;
        _logger = logger;
        _personRepository = personRepository;
    }

    [Authorize]
    public IActionResult Index()
    {
        var id = _userManager.GetUserId(User);
        UserListsViewModel uservm = new UserListsViewModel();
        //uservm.LoggedInUser = _personRepository.FindById(userId);
        

        return View("Index", uservm);
    }

    public IActionResult AddList(int userId, int listType)
    {
        // call the method in the personrepository to add the list
        var person = _personRepository.FindById(userId);
        if (person == null)
        {
            return View("Error");
        }
        
        throw new NotImplementedException();

    }
}