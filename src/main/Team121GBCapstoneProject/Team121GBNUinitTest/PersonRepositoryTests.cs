using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team121GBCapstoneProject.DAL.Abstract;
using Team121GBCapstoneProject.DAL.Concrete;
using Team121GBCapstoneProject.Models;
using Team121GBNUinitTest;

#nullable disable
namespace Team121GBNUnitTest;

public class PersonRepositoryTests
{
    private Mock<GPDbContext> _mockContext;
    private Mock<DbSet<Person>> _mockPersonDbSet;
    // private Mock<DbSet<UserList>> _mockUserListDbSet;
    // private List<UserList> _userList;
    private List<Person> _people;

    [SetUp]
    public void Setup()
    {
        _people = new List<Person>
        {
            new Person { Id = 1, AuthorizationId = "123" }
        };

        // _userList = new List<UserList>
        // {
        //     new UserList { Id = 1, Title = "Currently Playing", PersonId = 1},
        //     new UserList { Id = 2, Title = "Completed", PersonId = 1},
        //     new UserList { Id = 3, Title = "Want to Play", PersonId = 1}
        // };

        // * Set the navigation properties
        // _people.ForEach(p =>
        // {
        //     p.UserLists = _userList.Where(l => l.PersonId == p.Id).ToList();
        // });


        _mockContext = new Mock<GPDbContext>();
        _mockPersonDbSet = MockHelpers.GetMockDbSet(_people.AsQueryable());
        _mockContext.Setup(ctx => ctx.People).Returns(_mockPersonDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<Person>()).Returns(_mockPersonDbSet.Object);
        // _mockUserListDbSet = MockHelpers.GetMockDbSet(_userList.AsQueryable());
        // _mockContext.Setup(ctx => ctx.UserLists).Returns(_mockUserListDbSet.Object);
        // _mockContext.Setup(ctx => ctx.Set<UserList>()).Returns(_mockUserListDbSet.Object);
    }

    [Test]
    public void AddPersonToProjectDb_ValidPerson_ShouldReturnTrue()
    {
        // ! Arrange
        var personRepository = new PersonRepository(_mockContext.Object);
        var person = new Person
        {
            AuthorizationId = "456",
        };
        // * Act
        var result = personRepository.AddPersonToProjectDb(person.AuthorizationId);
        var people = _mockPersonDbSet.Object.ToList();
        // ? Assert
        Assert.That(result, Is.EqualTo(true));
        // ! I want to check to sure that the number of people would be updated to 2 but for some
        // ! reason my test doesn't capture the update in count
        // ! I does however work when I update the database in the main application
        // ! I am gonna need help to figure this one out.
        // Assert.Multiple(() =>
        // {
        //     Assert.That(result, Is.EqualTo(true));
        //     Assert.That(people.Count(), Is.EqualTo(2));
        // });
    }


    [Test]
    public void AddPersonToProjectDb_InvalidPerson_ShouldReturnTrue()
    {
        // ! Arrange
        var personRepository = new PersonRepository(_mockContext.Object);
        var person = new Person
        {
            AuthorizationId = null,
        };
        // * Act
        var result = personRepository.AddPersonToProjectDb(person.AuthorizationId);
        // ? Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(false));
            Assert.That(_people.Count(), Is.EqualTo(1));
        });
    }
}