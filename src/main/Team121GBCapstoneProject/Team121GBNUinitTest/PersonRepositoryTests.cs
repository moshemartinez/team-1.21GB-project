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

namespace Team121GBNUnitTest;

public class PersonRepositoryTests
{
    private Mock<GPDbContext> _mockContext;
    private Mock<DbSet<UserList>> _mockUserListDbSet;
    private List<UserList> _userList;
    private Person _person;

    [SetUp]
    public void Setup()
    {
        _person = new Person
        {
            Id = 1,
            AuthorizationId = "123",
            CurrentlyPlayingListId = 1,
            CompletedListId = 2,
            WantToPlayListId = 3
        };

        _userList = new List<UserList>
        {
            new UserList { Id = 1, Title = "Currently Playing", PersonId = 1},
            new UserList { Id = 2, Title = "Completed", PersonId = 1},
            new UserList { Id = 3, Title = "Want to Play", PersonId = 1}
        };

        _mockContext = new Mock<GPDbContext>();
        _mockUserListDbSet = MockHelpers.GetMockDbSet(_userList.AsQueryable());
        _mockContext.Setup(ctx => ctx.UserLists).Returns(_mockUserListDbSet.Object);
        _mockContext.Setup(ctx => ctx.Set<UserList>()).Returns(_mockUserListDbSet.Object);
    }

    [Test]
    public void AddOrUpdate_Person_ShouldReturnTrue()
    {
        // ! Arrange
        Person  person = new Person 
        {
            Id = 2,
            AuthorizationId = "456",
            CurrentlyPlayingListId = null,
            CompletedListId = null,
            WantToPlayListId = null
        };
        // * Act

        // ? Assert
        Assert.Fail();
    }

}