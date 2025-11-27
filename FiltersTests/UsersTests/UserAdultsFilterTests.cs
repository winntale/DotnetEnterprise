using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class UserAdultsFilterTests
{
    private readonly UsersFilter _usersFilter = new();

    [Fact]
    public void AllAdultUsers_ShouldReturnFalse_WhenNullInput()
    {
        // Arrange
        ICollection<User>? users = null;
        
        // Act
        var result = _usersFilter.AllAdultUsers(users);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AllAdultUsers_ShouldReturnFalse_WhenNotAllAreAdults()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "John Doe", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Alex", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Spark", Age = 16 },
            new() { Id = Guid.NewGuid(), Name = "Lora", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Mask", Age = 18 }
        };
        
        // Act
        var result = _usersFilter.AllAdultUsers(users);
        
        // Assert 
        Assert.False(result);
    }

    [Fact]
    public void AllAdultUsers_ShouldReturnTrue_WhenAllAreAdults()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "John Doe", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Alex", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Spark", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "Lora", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Mask", Age = 18 }
        };
        
        // Act
        var result = _usersFilter.AllAdultUsers(users);
        
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void AnyAdultUsers_ShouldReturnFalse_WhenNullInput()
    {
        // Arrange
        ICollection<User>? users = null;
        
        // Act
        var result = _usersFilter.AnyAdultUsers(users);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void AnyAdultUsers_ShouldReturnFalse_WhenNoOnesAdult()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Michael", Age = 15 },
            new() { Id = Guid.NewGuid(), Name = "Oleg", Age = 14 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Sasha", Age = 12 }
        };
        
        // Act
        var result = _usersFilter.AnyAdultUsers(users);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void AnyAdultUsers_ShouldReturnTrue_WhenThereIsAnAdult()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Michael", Age = 15 },
            new() { Id = Guid.NewGuid(), Name = "Oleg", Age = 25 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Sasha", Age = 12 }
        };
        
        // Act
        var result = _usersFilter.AnyAdultUsers(users);
        
        // Assert
        Assert.True(result);
    }
    
    [Fact]
    public void ContainsAdultUser_ShouldReturnFalse_WhenNullInput()
    {
        // Arrange
        ICollection<User>? users = null;
        
        // Act
        var result = _usersFilter.ContainsAdultUser(users);
        
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void ContainsAdultUser_ShouldReturnFalse_WhenNoOnesAdult()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Michael", Age = 15 },
            new() { Id = Guid.NewGuid(), Name = "Oleg", Age = 14 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Sasha", Age = 12 }
        };
        
        // Act
        var result = _usersFilter.ContainsAdultUser(users);
        
        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ContainsAdultUser_ShouldReturnTrue_WhenThereIsAnAdult()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Michael", Age = 15 },
            new() { Id = Guid.NewGuid(), Name = "Oleg", Age = 18 },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "Sasha", Age = 12 }
        };
        
        // Act
        var result = _usersFilter.ContainsAdultUser(users);
        
        // Assert
        Assert.True(result);
    }
    
}