using System.Collections.Generic;
using FiltersApp;
using FiltersApp.Models;
using Xunit;
using Xunit.Abstractions;

namespace NumbersFilterTests.UsersTests;

public class UniqueUsersTests
{
    private readonly ITestOutputHelper _output;
    private readonly UsersFilter _usersFilter = new();
    private User CreateUser(Guid id, int age, string name) => 
        new() { Id = id, Age = age, Name = name };

    [Fact]
    public void EmptyCollection_ReturnsEmptyHashSet()
    {
        // Arrange
        var users = new List<User>();

        // Act
        var result = _usersFilter.UniqueUsers(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SingleUser_ReturnsHashSetWithOneUser()
    {
        // Arrange
        var user = CreateUser(Guid.NewGuid(), 25, "Alice");
        var users = new List<User> { user };

        // Act
        var result = _usersFilter.UniqueUsers(users);

        // Assert
        Assert.Single(result);
        Assert.Contains(user, result);
    }

    [Fact]
    public void DifferentUsers_ReturnsAllUniqueUsers()
    {
        // Arrange
        var user1 = CreateUser(Guid.Parse("11111111-1111-1111-1111-111111111111"), 25, "Alice");
        var user2 = CreateUser(Guid.Parse("22222222-2222-2222-2222-222222222222"), 30, "Bob");
        var users = new List<User> { user1, user2 };

        // Act
        var result = _usersFilter.UniqueUsers(users);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(user1, result);
        Assert.Contains(user2, result);
    }
}
