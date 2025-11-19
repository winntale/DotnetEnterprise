using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class SelectUserIdsTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void SelectUserIds_ShouldReturnEmpty_WhenNullInput()
    {
        // Arrange
        ICollection<User>? users = null;

        // Act
        var result = _usersFilter.SelectUserIds(users, 20);

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void SelectUserIds_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<User>? users = new List<User>();
        
        // Act
        var result = _usersFilter.SelectUserIds(users, 20);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SelectUserIds_ShouldReturnIds_WhenCorrectInput()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "John", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Jane", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "James", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Barbara", Age = 15 }
        };
        var age = 20;
        var expectingUsers = new List<Guid> { users[1].Id, users[3].Id };
        
        // Act
        var result = _usersFilter.SelectUserIds(users, age);
        
        // Assert
        Assert.Equal( expectingUsers, result);
    }

    [Fact]
    public void SelectUserIds_ShouldReturnAllIds_WhenNegativeInput()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "John", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Jane", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "James", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Barbara", Age = 15 }
        };
        var age = -1;
        var expectingUsers = users.Select(user => user.Id).ToList();
        
        // Act
        var result = _usersFilter.SelectUserIds(users, age);
        
        // Assert
        Assert.Equal(expectingUsers, result);
    }

    [Fact]
    public void SelectUserIds_ShouldReturnEmpty_WhenIntMaxInput()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "John", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Jane", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "James", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Barbara", Age = 15 }
        };
        var age = Int32.MaxValue;
        
        // Act
        var result = _usersFilter.SelectUserIds(users, age);
        
        // Assert
        Assert.Empty(result);
    }
}