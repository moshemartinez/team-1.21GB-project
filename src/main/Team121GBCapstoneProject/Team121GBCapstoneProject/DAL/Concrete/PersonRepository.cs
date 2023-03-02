using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.Models;

namespace Team121GBCapstoneProject.DAL.Concrete;

public class PersonRepository : IPersonRepository
{
    public Person AddOrUpdate(Person entity)
    {
        throw new NotImplementedException();
    }

    //! Commenting this out to see if I can accomplish the same with AddOrUpdate
    // public bool AddPersonToProjectDb(string authorizationId)
    // {
    //     throw new NotImplementedException();
    // }

    public void Delete(Person entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public Person FindById(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Person> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Person> GetAll(params Expression<Func<Person, object>>[] includes)
    {
        throw new NotImplementedException();
    }
}