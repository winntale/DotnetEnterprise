using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class GetPaginateUsersTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void GetPaginateUsers_ShouldReturnEmptyPage_WhenEmptyInput()
    {
        // Arrange
        IList<User> users = [];
        
        // Act
        var resultingPaginate = _usersFilter.GetPaginateUsers(users, 0, 10);
        var result = resultingPaginate.CurrentPageUsers;
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetPaginateUsers_ShouldReturnEmptyPage_WhenTakesOutOfRange()
    {
        // Arrange
        IList<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 43 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Olga", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Vladislav", Age = 30 }
        };
        
        // Act
        var resultingPaginate = _usersFilter.GetPaginateUsers(users, 8, 10);
        var result = resultingPaginate.CurrentPageUsers;
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void GetPaginateUsers_ShouldReturnEmptyPage_WhenZeroTakes()
    {
        // Arrange
        IList<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 43 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Olga", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Vladislav", Age = 30 }
        };
        
        // Act
        var resultingPaginate = _usersFilter.GetPaginateUsers(users, 0, 0);
        var result = resultingPaginate.CurrentPageUsers;
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetPaginateUsers_ShouldReturnPage_WhenCorrectInput()
    {
        // Arrange
        IList<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 43 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Olga", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Vladislav", Age = 30 },
            new() { Id = Guid.NewGuid(), Name = "Sergey", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Alena", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Felix", Age = 25 },
            new() { Id = Guid.NewGuid(), Name = "George", Age = 31 },
            new() { Id = Guid.NewGuid(), Name = "Nansi", Age = 24 },
            new() { Id = Guid.NewGuid(), Name = "Sabina", Age = 16 }
        };
        var expectedResult = new List<User> { users[10], users[11] };
        
        // Act
        var resultingPaginate = _usersFilter.GetPaginateUsers(users, 1, 10);
        var result = resultingPaginate.CurrentPageUsers;
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}