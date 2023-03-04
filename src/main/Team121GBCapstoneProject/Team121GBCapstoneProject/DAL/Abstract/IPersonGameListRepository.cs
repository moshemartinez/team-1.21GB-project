using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract;
public interface IPersonGameListRepository : IRepository<PersonGameList>
{
    //public bool AddPersonToProjectDb(string authorizationID);
    public bool CheckIfUserHasCustomListWithSameName (Person user, string listName);
    public bool CheckIfUserHasDefaultListAlready (Person user, int listType);
    public bool AddDefaultList(Person user, int listType, string listName);
    public void AddCustomList(Person user, GamePlayListType listType, ListName listName);

}
