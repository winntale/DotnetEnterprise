using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class DescendingAgeUsersTests
{
    private readonly UsersFilter _filterUsers = new();

    [Fact]
    public void DescendingAgeUsers_ShouldReturnEmpty_WhereNullInput()
    {
        // Arrange
        ICollection<User>? users = null;

        // Act
        var result = _filterUsers.DescendingAgeUsers(users, 18);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void DescendingAgeUsers_ShouldReturnEmpty_WhereEmptyInput()
    {
        // Arrange
        ICollection<User> users = [];
        
        // Act
        var result = _filterUsers.DescendingAgeUsers(users, 18);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void DescendingAgeUsers_ShouldReturnEmpty_WhereNoMatchesInput()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 }
        };
        
        // Act
        var result = _filterUsers.DescendingAgeUsers(users, 18);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void DescendingAgeUsers_ShouldReturnSortedUsers_WhereCorrectInput()
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

        IList<User> expectingUsers = new List<User> { users[1], users[5], users[0], users[4] }; // Robert, Vladislav, Aleksey, Olga

        // Act
        var result = _filterUsers.DescendingAgeUsers(users, 18);

        // Assert
        Assert.Equal(expectingUsers, result);
    }
}