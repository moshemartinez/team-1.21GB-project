using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Abstract
{
    public interface IPersonListRepository : IRepository<PersonList>
    {
        public bool AddDefaultListsOnAccountCreation(string authorizationId);
    }
}
