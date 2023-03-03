using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract;
public interface IPersonRepository : IRepository<Person>
{
    public bool AddPersonToProjectDb(string authorizationID);
    public bool AddList(Person user, int listType, string listName);

}
