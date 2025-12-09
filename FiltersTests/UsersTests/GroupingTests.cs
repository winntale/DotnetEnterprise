using FiltersApp;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.UsersTests;

public class GroupingTests
{
    private readonly UsersFilter _usersFilter = new();
    
    private static readonly User[] UsersWithDuplicates = new[]
    {
        new User { Id = Guid.NewGuid(), Age = 25, Name = "Alice" },
        new User { Id = Guid.NewGuid(), Age = 25, Name = "Bob" }, // Дубликат!
        new User { Id = Guid.NewGuid(), Age = 30, Name = "Charlie" }
    };

    private static readonly User[] UsersUniqueAges = new[]
    {
        new User { Id = Guid.NewGuid(), Age = 25, Name = "Alice" },
        new User { Id = Guid.NewGuid(), Age = 30, Name = "Charlie" }
    };

    [Fact]
    public void Dictionary_WithDuplicateAges_ThrowsException()
    {
        // Arrange
        var users = UsersWithDuplicates;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            _usersFilter.GroupByAgeUsingDictionary(users));
    }

    [Fact]
    public void Lookup_WithDuplicateAges_GroupsAllUsers()
    {
        // Arrange
        var users = UsersWithDuplicates;

        // Act
        var result = _usersFilter.GroupByAgeUsingLookup(users);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(2, result[25].Count());
        Assert.Single(result[30]);
        Assert.Empty(result[99]);
    }

    [Fact]
    public void Dictionary_MissingKey_ThrowsKeyNotFound()
    {
        // Arrange
        var dict = _usersFilter.GroupByAgeUsingDictionary(UsersUniqueAges);

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() =>
            _ = dict[99]);
        Assert.True(dict.TryGetValue(25, out _));
    }

    [Fact]
    public void Dictionary_WithUniqueAges_WorksNormally()
    {
        // Arrange & Act
        var result = _usersFilter.GroupByAgeUsingDictionary(UsersUniqueAges);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Alice", result[25].Name);
    }
}