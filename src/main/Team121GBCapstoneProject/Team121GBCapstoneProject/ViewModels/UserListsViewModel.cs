using Microsoft.AspNetCore.Mvc.Rendering;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.ViewModels;

public class UserListsViewModel
{
    public Person LoggedInUser { get; set; }
    //public List<SelectListItem> SelectListItems { get; set; }
    public List<PersonGameList> GameLists { get; set; }
    //public List<List<PersonGameList>> UsersLists { get; set; }
    public List<List<PersonGameList>> UsersLists { get; set; }
    public UserListsViewModel() { }
    public UserListsViewModel(Person user, List<PersonGameList> userGames)
    {
        LoggedInUser = user;
        
        var temp = userGames.OrderBy(listName => listName.ListNameId)
                            .ToList();

        var t = userGames.OrderBy(listName => listName.ListNameId)
                              .GroupBy(listNameId => listNameId.ListNameId)
                              .Select(group => group.ToList())
                              .ToList();

        // old version
        var group = temp.GroupBy(listNameId => listNameId.ListNameId)
                        .ToList();
        UsersLists = new List<List<PersonGameList>>();
        foreach (var item in group)
        {
            var list = item.ToList();
            UsersLists.Add(list);
        }

    }
}