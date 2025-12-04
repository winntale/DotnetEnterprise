using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class FindUsersWithSameName
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void FindUsersWithSameName_ShouldReturnEmpty_WhenAllGroupsEmptyInput()
    {
        // Arrange
        ICollection<User> firstUserGroup = [];
        ICollection<User> secondUserGroup = [];
        
        // Act
        var result = _usersFilter.FindUsersWithSameName(firstUserGroup, secondUserGroup);
        
        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void FindUsersWithSameName_ShouldReturnEmpty_WhenOneOfGroupsEmptyInput()
    {
        // Arrange
        ICollection<User> firstUserGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Age = 32, Name = "Bob" },
            new() { Id = Guid.NewGuid(), Age = 31, Name = "Robert" },
            new() { Id = Guid.NewGuid(), Age = 25, Name = "Max" },
            new() { Id = Guid.NewGuid(), Age = 18, Name = "Nikita" },
        };
        ICollection<User> secondUserGroup = [];
        
        // Act
        var result = _usersFilter.FindUsersWithSameName(firstUserGroup, secondUserGroup);
        
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindUsersWithSameName_ShouldReturnUsersWithSameNames_WhenGroupsHasSome()
    {
        // Arrange
        IList<User> firstUserGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Age = 32, Name = "Bob" },
            new() { Id = Guid.NewGuid(), Age = 31, Name = "Robert" },
            new() { Id = Guid.NewGuid(), Age = 25, Name = "Max" },
            new() { Id = Guid.NewGuid(), Age = 18, Name = "Nikita" },
        };
        IList<User> secondUserGroup = new List<User>
        {
            new() { Id = Guid.NewGuid(), Age = 14, Name = "Bob" },
            new() { Id = Guid.NewGuid(), Age = 18, Name = "Jorge" },
            new() { Id = Guid.NewGuid(), Age = 18, Name = "Nikita" },
            new() { Id = Guid.NewGuid(), Age = 36, Name = "Alex" },
        };
        IList<User> expectedResult = new List<User>
        {
            firstUserGroup[0], firstUserGroup[3]
        };
        
        // Act
        var result = _usersFilter.FindUsersWithSameName(firstUserGroup, secondUserGroup);
        
        // Assert
        Assert.Equal(expectedResult, result);
    }
}