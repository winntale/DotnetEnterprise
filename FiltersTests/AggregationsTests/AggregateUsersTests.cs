using FiltersApp.Models;
using FiltersApp.UsersAPI;
using Xunit;

namespace NumbersFilterTests.AggregationsTests;

public class UserStatisticsTests
{
    private readonly AggregateUsers _stats = new();
    private static readonly User User1 = new() { Id = Guid.NewGuid(), Name = "Иван", Age = 20 };
    private static readonly User User2 = new() { Id = Guid.NewGuid(), Name = "Анна", Age = 25 };
    private static readonly User User3 = new() { Id = Guid.NewGuid(), Name = "Петр", Age = 30 };

    [Fact]
    public void CountUsers_ShouldReturnCorrectCount()
    {
        // Arrange
        var users = new List<User> { User1, User2 };

        // Act
        var result = _stats.CountUsers(users);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void CountUsers_ShouldReturnZero_ForEmptyCollection()
    {
        var users = new List<User>();

        var result = _stats.CountUsers(users);

        Assert.Equal(0, result);
    }

    [Fact]
    public void CountUsers_ShouldThrow_ForNull()
    {
        Assert.Throws<ArgumentNullException>(() => _stats.CountUsers(null!));
    }

    [Fact]
    public void GetMaxAge_ShouldReturnMaxValue()
    {
        var users = new List<User> { User1, User2, User3 };

        var result = _stats.GetMaxAge(users);

        Assert.Equal(30, result);
    }

    [Fact]
    public void GetMaxAge_ShouldThrow_ForEmptyCollection()
    {
        var users = new List<User>();

        Assert.Throws<InvalidOperationException>(() => _stats.GetMaxAge(users));
    }

    [Fact]
    public void GetMinAge_ShouldReturnMinValue()
    {
        var users = new List<User> { User1, User2, User3 };

        var result = _stats.GetMinAge(users);

        Assert.Equal(20, result);
    }

    [Fact]
    public void GetMinAge_ShouldThrow_ForEmptyCollection()
    {
        var users = new List<User>();

        Assert.Throws<InvalidOperationException>(() => _stats.GetMinAge(users));
    }

    [Fact]
    public void SumAges_ShouldReturnCorrectSum()
    {
        var users = new List<User> { User1, User2, User3 };

        var result = _stats.SumAges(users);

        Assert.Equal(75, result);
    }

    [Fact]
    public void SumAges_ShouldReturnZero_ForEmptyCollection()
    {
        var users = new List<User>();

        var result = _stats.SumAges(users);

        Assert.Equal(0, result);
    }
}
