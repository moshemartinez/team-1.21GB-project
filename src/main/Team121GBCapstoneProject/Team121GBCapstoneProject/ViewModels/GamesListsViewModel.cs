using Microsoft.AspNetCore.Mvc.Rendering;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.ViewModels;

public class UserListsViewModel 
{
    public Person LoggedInUser { get; set; }
    public List<SelectListItem> SelectListItems { get; set; }
    public List<PersonGameList> UsersLists { get; set; }
    public List<GamePlayListType> ListTypes { get; set; }
}