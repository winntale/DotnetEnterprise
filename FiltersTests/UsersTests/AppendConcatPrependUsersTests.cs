using FiltersApp;
using Xunit;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class AppendConcatPrependUsersTests
{
    private static readonly User User1 = new() { Id = Guid.NewGuid(), Name = "Иван", Age = 20 };
    private static readonly User User2 = new() { Id = Guid.NewGuid(), Name = "Анна", Age = 21 };
    private static readonly User NewUser = new() { Id = Guid.NewGuid(), Name = "Петр", Age = 23 };

    private readonly UsersFilter _usersFilter = new();
    
    [Fact]
    public void AddUserAtEnd_ShouldAppendToEmptyCollection()
    {
        // Arrange
        ICollection<User> users = [];
    
        // Act
        var result = _usersFilter.AddUserAtEnd(users, NewUser);
    
        // Assert
        Assert.Single(result);
        Assert.Equal("Петр", result.First().Name);
    }

    [Fact]
    public void AddUserAtEnd_ShouldAddToEndOfExistingCollection()
    {
        // Arrange
        ICollection<User> users = new List<User> { User1, User2 };
    
        // Act
        var result = _usersFilter.AddUserAtEnd(users, NewUser);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Петр", result.Last().Name);
        Assert.Equal("Анна", result.ElementAt(1).Name);
    }
    
    
    [Fact]
    public void MergeUserCollections_ShouldReturnEmpty_WhenBothEmpty()
    {
        // Arrange
        ICollection<User> firstGroup = [];
        ICollection<User> secondGroup = [];
    
        // Act
        var result = _usersFilter.MergeUserCollections(firstGroup, secondGroup);
    
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void MergeUserCollections_ShouldPreserveOrder_FirstThenSecond()
    {
        // Arrange
        ICollection<User> firstGroup = [User1];
        ICollection<User> secondGroup = [User2, NewUser];
    
        // Act
        var result = _usersFilter.MergeUserCollections(firstGroup, secondGroup);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Иван", result.First().Name);
        Assert.Equal("Петр", result.Last().Name);
    }

    [Fact]
    public void MergeUserCollections_ShouldHandleOneEmptyCollection()
    {
        // Arrange
        ICollection<User> firstGroup = [User1, User2];
        ICollection<User> secondGroup = [];
    
        // Act
        var result = _usersFilter.MergeUserCollections(firstGroup, secondGroup);
    
        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Иван", result.First().Name);
    }

    
    [Fact]
    public void AddUserAtBeginning_ShouldPrependToEmptyCollection()
    {
        // Arrange
        ICollection<User> users = [];
    
        // Act
        var result = _usersFilter.AddUserAtBeginning(users, NewUser);
    
        // Assert
        Assert.Single(result);
        Assert.Equal("Петр", result.First().Name);
    }

    [Fact]
    public void AddUserAtBeginning_ShouldAddToStartOfExistingCollection()
    {
        // Arrange
        ICollection<User> users = new List<User> { User1, User2 };
    
        // Act
        var result = _usersFilter.AddUserAtBeginning(users, NewUser);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Петр", result.First().Name);
        Assert.Equal("Иван", result.ElementAt(1).Name);
    }

    [Fact]
    public void AddUserAtBeginning_ShouldPreserveOriginalOrderAfterNewUser()
    {
        // Arrange
        ICollection<User> users = new List<User> { User1, User2 };
    
        // Act
        var result = _usersFilter.AddUserAtBeginning(users, NewUser);
    
        // Assert
        Assert.Equal("Иван", result.ElementAt(1).Name);
        Assert.Equal("Анна", result.Last().Name);
    }
}