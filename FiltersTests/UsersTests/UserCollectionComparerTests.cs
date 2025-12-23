using FiltersApp.Comparers.Users;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.UsersTests;

public class UserCollectionComparerTests
{
    private readonly UserCollectionComparer _comparer = new();
    private static readonly User user1 = new() { Id = Guid.NewGuid(), Name = "John Doe", Age = 18 };
    private static readonly User user2 = new() { Id = Guid.NewGuid(), Name = "Alex", Age = 18 };
    private readonly User user3 = new() { Id = Guid.NewGuid(), Name = "Alex", Age = 16 };
    private readonly List<User> usersA = [];
    private readonly List<User> usersB = [user1, user2];
    private readonly List<User> usersC = [user1, user2];
    private readonly List<User> usersD = [user2, user1];
    

    [Fact]
    public void AreCollectionsEqual_ShouldReturnTrue_ForIdenticalCollections()
    {
        var result = _comparer.AreCollectionsEqual(usersB, usersC);
        Assert.True(result);
    }

    [Fact]
    public void AreCollectionsEqual_ShouldReturnFalse_ForDifferentOrder()
    {
        var result = _comparer.AreCollectionsEqual(usersB, usersD);
        Assert.False(result);
    }

    [Fact]
    public void AreCollectionsEqual_ShouldReturnTrue_ForTwoEmpty()
    {
        var result = _comparer.AreCollectionsEqual([], []);
        Assert.True(result);
    }

    [Fact]
    public void AreCollectionsEqual_ShouldReturnFalse_ForEmptyVsNonEmpty()
    {
        var result = _comparer.AreCollectionsEqual([], usersB);
        Assert.False(result);
    }

    [Fact]
    public void AreCollectionsEqual_ShouldTreatNullAsEmpty()
    {
        var result = _comparer.AreCollectionsEqual(usersA, null);
        Assert.True(result);
        
        result = _comparer.AreCollectionsEqual(null, null);
        Assert.True(result);
        
        result = _comparer.AreCollectionsEqual(null, usersB);
        Assert.False(result);
    }

    [Fact]
    public void AreCollectionsEqual_WithComparer_ShouldCompareByAge()
    {
        List<User> usersDifferentIdSameName = [user2, user3];

        var result = _comparer.AreCollectionsEqual(
            usersDifferentIdSameName,
            new List<User> {user2, user3},
            new UserNameComparer());
        Assert.True(result);
    }
}