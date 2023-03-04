using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Team121GBCapstoneProject.Areas.Identity.Data;
using System.Diagnostics;

namespace Team121GBCapstoneProjects.Controllers;

public class GamesListsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<GamesListsController> _logger;
    private IPersonRepository _personRepository;
    // private readonly List<(int, string)> listTypes = new List<(int id, string name)> {(id: 1, name: "Currently Playing"), (id: 2, name: "Completed"), (id: 3, name: "Want to Play")};
    private readonly List<string> listTypes = new List<string> {"Currently Playing", "Completed", "Want to Play"};
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
        var temp = _personRepository.GetAll().Where(i => i.AuthorizationId == id);
        UserListsViewModel uservm = new UserListsViewModel();
        uservm.LoggedInUser = temp.First();
        //uservm.LoggedInUser = _personRepository.FindById(userId);


        return View("Index", uservm);
    }

    [HttpPost]
    public IActionResult AddList(int userId, int listType, string listName)
    {
        Person person = _personRepository.FindById(userId);
        UserListsViewModel userVM = new UserListsViewModel();
        userVM.LoggedInUser = person;

        if (person == null)
        {
            return View("Error");
        }

        //! listType == 4 means the list is a custom list.
        if (listType != 4 && listName != null)
        {
            ViewBag.ErrorMessage = $"A non custom list may not have a custom name!";
            return View("Index", userVM);
        }

        //check if the user already has a default list
        if (listType != 4)
        {
            bool check = _personRepository.CheckIfUserHasDefaultListAlready(person, listType);
            if (!check)
            {   // * listType- 1 because indexes are base zero
                ViewBag.ErrorMessage = $"You already have a {listTypes[listType-1]} List!";
                return View("Index", userVM);
            }
            // Set the default list name.
            listName = listTypes[listType-1];
             _personRepository.AddDefaultList(person, listType, listName);
        }

        if (listType == 4)
        {
            var check = _personRepository.CheckIfUserHasCustomListWithSameName(person, listName);
            if (check)
            {
                ViewBag.ErrorMessage = $"A list with the name {listName} already exists, try a different one!";
                return View("Index", userVM);
            }
        }

        //_personRepository.AddList(person, listType, listName);

        userVM.LoggedInUser = person;
        ViewBag.Message = "Success!";
        return View("Index", userVM);
    }
}