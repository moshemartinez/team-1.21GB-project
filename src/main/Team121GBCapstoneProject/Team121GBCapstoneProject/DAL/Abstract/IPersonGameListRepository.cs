using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract;
public interface IPersonGameListRepository : IRepository<PersonGameList>
{
    //public bool AddPersonToProjectDb(string authorizationID);
    public bool CheckIfUserHasCustomListWithSameName (Person user, string listName);
    public bool CheckIfUserHasDefaultListAlready (Person user, int listType);
    public void AddDefaultList(Person user, GamePlayListType listType, ListName listName);
    public void AddCustomList(Person user, GamePlayListType listType, ListName listName);
    //public void DeleteACustomList(Person user, string listName);
    //public void DeleteACustomList(Person user, List<int> idList);
    public void DeleteACustomList(List<PersonGameList> listToDelete);


}
