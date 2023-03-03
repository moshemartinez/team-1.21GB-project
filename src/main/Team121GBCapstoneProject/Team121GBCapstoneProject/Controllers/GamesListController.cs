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

    public IActionResult AddList(int userId, int listType, string customListName)
    {
        // call the method in the personrepository to add the list
        var person = _personRepository.FindById(userId);
        if (person == null)
        {
            return View("Error");
        }
        var userLists = person.PersonGameLists.ToList();//.Contains(listType);
        

        foreach(var checklist in userLists)
        {
            //If it is a custom list let them create it.
            if(checklist.ListKindId == 4)
            {
                break;
            }
            if(checklist.ListKindId == listType)
            {
                Debug.WriteLine("User already has a list of this type");
                return View("Index");
            }
        }

        _personRepository.AddList(person, listType);
        
        var userVM = new UserListsViewModel();
        userVM.LoggedInUser = person;

        return View("Index", userVM);
    }
}