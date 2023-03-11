using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Models;

namespace Team121GBNUnitTest;

public class PersonListRepositoryTests
{
    private static readonly string _seedFile = @"..\..\..\Data\seed.sql"; // relative path from where the executable is: bin/Debug/net7.0
    // Create this helper like this, for whatever context you desire
    private InMemoryDbHelper<GPDbContext> _dbHelper = new InMemoryDbHelper<GPDbContext>(_seedFile, DbPersistence.OneDbPerTest);

    [Test]
    public void GPDbContext_CreateDefaultLists_Success_ShouldReturnTrue()
    {
        // * Arrange 
        using GPDbContext context = _dbHelper.GetContext();
        PersonListRepository personListRepository = new PersonListRepository(context);
        Person person = new Person
        {

        };
        PersonList personList = new PersonList
        {

        };
        // ! Act

        // ? Assert

    }

    [Test]
    public void GPDbContext_CreateDefaultLists_Failure_PersonIsNull_ShouldReturnFalse()
    {
        // * Arrange 
        using GPDbContext context = _dbHelper.GetContext();
        PersonListRepository personListRepository = new PersonListRepository(context);
        Person person = null;
        PersonList personList = new PersonList();
        // ! Act

        // ? Assert

    }
    [Test]
    public void GPDbContext_CreateDefaultLists_Failure_ListNameIsNull_ShouldReturnFalse()
    {
        // * Arrange 
        using GPDbContext context = _dbHelper.GetContext();
        PersonListRepository personListRepository = new PersonListRepository(context);

        // ! Act

        // ? Assert

    }
    [Test]
    public void GPDbContext_CreateDefaultLists_Failure_ListNameIsEmpty_ShouldReturnFalse()
    {
        // * Arrange 
        using GPDbContext context = _dbHelper.GetContext();
        PersonListRepository personListRepository = new PersonListRepository(context);

        // ! Act

        // ? Assert

    }
}

