using Team121GBCapstoneProject.Models;
using Team121GBCapstoneProject.DAL.Abstract;
using System.Linq.Expressions;

namespace Team121GBCapstoneProject.DAL.Concrete;

public class PersonGameListRepository : Repository<PersonGameList>, IPersonGameListRepository
{
    public PersonGameListRepository(GPDbContext ctx) : base(ctx)
    {

    }
    public bool CheckIfUserHasCustomListWithSameName(Person user, string listName)
    {
        bool check = false;
        List<PersonGameList> listNames = user.PersonGameLists.ToList();

        // ! check if a list of the same name exists for user.
        foreach (var list in listNames)
        {
            if (list.ListName.NameOfList == listName)
            {
                check = true;
                return check;
            }
        }
        return check;
    }
    public bool CheckIfUserHasDefaultListAlready(Person user, int listType)
    {
        bool check = false;
        List<PersonGameList> listTypes = user.PersonGameLists.ToList();
        foreach (var list in listTypes)
        {
            if (list.ListKindId == listType) return check;
        }
        check = true;
        return check;
    }

    public bool AddDefaultList(Person user, int listType, string listName)
    {
        PersonGameList newList = new PersonGameList();
        ListName listNameObj = new ListName();
        newList.ListKindId = listType;
        if (listType != 4)
        {

        }
        listNameObj.NameOfList = listName;

        //user.PersonGameLists.Add
        return false;
    }

    public bool AddCustomList(Person user, int listType, string listName)
    {
        bool status = false;
        PersonGameList newList = new PersonGameList();
        ListName listNameObj = new ListName();
        GamePlayListType listKind = new GamePlayListType();

        listKind.Id = listType;
        listKind.ListKind = ""; // ! How do I put the list kind here? or do I need to...
        listNameObj.NameOfList = listName;

        newList.ListName = listNameObj;
        newList.Person = user;
        newList.ListKind = listKind;

        //user.PersonGameLists.Add
        //AddOrUpdate();
        return status;
    }
}