using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(GPDbContext ctx) : base(ctx)
    {

    }

    public bool AddPersonToProjectDb(string authorizationID)
    {
        if (authorizationID == null)
        {
            return false;
        }
        else
        {
            try
            {
                Person GPPerson = new Person
                {
                    AuthorizationId = authorizationID
                };
                AddOrUpdate(GPPerson);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
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
                check = false;
                return check;
            }
            else
            {
                check = true;
            }
        }
        return check;
    }
    public bool CheckIfUserHasDefaultListAlready (Person user, int listType)
    {
        bool check = false;
        List<PersonGameList> listTypes = user.PersonGameLists.ToList();
        foreach(var list in listTypes)
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
        throw new NotImplementedException();
    }
}