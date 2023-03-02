using Microsoft.EntityFrameworkCore;
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
        //create the default lists

        throw new NotImplementedException();
    }
}