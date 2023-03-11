using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete;

public class PersonListRepository : Repository<PersonList>, IPersonListRepository
{
    public PersonListRepository(GPDbContext ctx) : base(ctx)
    {
    }

    public bool AddDefaultListsOnAccountCreation(string authorizationId)
    {

        throw new NotImplementedException();
    }
}

