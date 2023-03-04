using Microsoft.AspNetCore.Mvc;
using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Team121GBCapstoneProject.Areas.Identity.Data;
using System.Diagnostics;
using Team121GBCapstoneProject.DAL.Concrete;

namespace Team121GBCapstoneProjects.Controllers;

public class GamesListsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<GamesListsController> _logger;
    private IPersonRepository _personRepository;
    private IPersonGameListRepository _personGameListRepository;
    private IRepository<ListName> _listNameRepository;
    private IRepository<GamePlayListType> _gamePlayListType;
    private readonly List<string> listTypes = new List<string> { "Currently Playing", "Completed", "Want to Play" };
    public GamesListsController(UserManager<ApplicationUser> userManager,
                                 ILogger<GamesListsController> logger,
                                 IPersonRepository personRepository,
                                 IPersonGameListRepository personGameListRepository,
                                 IRepository<ListName> listNameRepository,
                                 IRepository<GamePlayListType> gamePlayListType)
    {
        _userManager = userManager;
        _logger = logger;
        _personRepository = personRepository;
        _personGameListRepository = personGameListRepository;
        _listNameRepository = listNameRepository;
        _gamePlayListType = gamePlayListType;
    }

    [Authorize]
    public IActionResult Index()
    {
        var loggedInUser = _personRepository.GetAll()
                                               .Where(user => user.AuthorizationId == _userManager.GetUserId(User))
                                               .First();
        //var temp = _personGameListRepository.GetAll()
        //                                    .Where(lists => lists.PersonId == userVM.LoggedInUser.Id &&
        //                                    lists.GameId != null)
        //                                    .ToList();

        var usersLists = _personGameListRepository.GetAll()
                                                     .Where(lists => lists.PersonId == loggedInUser.Id &&
                                                      lists.GameId != null)
                                                     .ToList();

        UserListsViewModel userVM = new UserListsViewModel(loggedInUser, usersLists);
        
        return View("Index", userVM);
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
            bool check = _personGameListRepository.CheckIfUserHasDefaultListAlready(person, listType);
            if (!check)
            {   // * listType- 1 because indexes are base zero
                ViewBag.ErrorMessage = $"You already have a {listTypes[listType - 1]} List!";
                return View("Index", userVM);
            }
            // Set the default list name.
            listName = listTypes[listType - 1];
            _personGameListRepository.AddDefaultList(person, listType, listName);
        }

        if (listType == 4)
        {
            var check = _personGameListRepository.CheckIfUserHasCustomListWithSameName(person, listName);
            if (check)
            {
                ViewBag.ErrorMessage = $"A list with the name {listName} already exists, try a different one!";
                return View("Index", userVM);
            }
            else
            {
                try
                {
                    GamePlayListType gamePlayListType = _gamePlayListType.FindById(listType);
                    ListName listNameObj = new ListName { NameOfList = listName };
                    listNameObj = _listNameRepository.AddOrUpdate(listNameObj);
                    _personGameListRepository.AddCustomList(person, gamePlayListType, listNameObj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    ViewBag.ErrorMessage = $"Something went wrong, please try again.";
                    return View("Index", userVM);
                }
            }
        }

        //_personRepository.AddList(person, listType, listName);

        userVM.LoggedInUser = person;
        ViewBag.Message = "Success!";
        return View("Index", userVM);
    }
}