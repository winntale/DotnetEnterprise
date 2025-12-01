using System.Collections;
using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class GroupUsersByAgeTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void GroupUsersByAge_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<User> users = new List<User>();
        
        // Act
        var result = _usersFilter.GroupUsersByAge(users);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GroupUsersByAge_ShouldReturnDictionary_WhenCorrectInput()
    {
        // Arrange
        IList<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Olga", Age = 19 },
            new() { Id = Guid.NewGuid(), Name = "Vladislav", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Sergey", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Alena", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Felix", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "George", Age = 25 },
            new() { Id = Guid.NewGuid(), Name = "Nansi", Age = 25 },
            new() { Id = Guid.NewGuid(), Name = "Sabina", Age = 25 }
        };
        
        List<User> GetUsersRange(int start, int count) => users.Skip(start).Take(count).ToList();
        
        var expectedResult = new Dictionary<int, List<User>>
        {
            { 18, GetUsersRange(0, 4) },
            { 19, GetUsersRange(4, 1) },
            { 20, GetUsersRange(5, 2) },
            { 21, GetUsersRange(7, 1) },
            { 23, GetUsersRange(8, 1) },
            { 25, GetUsersRange(9, 3) }
        };
        
        // Act
        var result = _usersFilter.GroupUsersByAge(users);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void GroupUsersByAge_ShouldReturnDictionaryWithOneGroup_WhenAllHasTheSameAge()
    {
        // Arrange
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Anna", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Olga", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Vladislav", Age = 18 }
        };
        
        var expectedResult = new Dictionary<int, List<User>>
        {
            { 18, users }
        };
        
        // Act
        var result = _usersFilter.GroupUsersByAge(users);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}