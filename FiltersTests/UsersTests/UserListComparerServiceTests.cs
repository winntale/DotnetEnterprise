using FiltersApp.Comparers.Users;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.UsersTests;

public class UserListComparerServiceTests
{
    private readonly UserListComparerService _comparer = new();
    private static readonly User user1 = new() { Id = Guid.NewGuid(), Age = 25 };
    private readonly User user2 = new() { Id = Guid.NewGuid(), Age = 30 };
    private readonly User user3 = new() { Id = user1.Id, Age = 25 };

    [Fact]
    public void AreSequencesEqual_ShouldReturnTrue_ForIdenticalRecords()
    {
        var list1 = new List<User> { user1, user2 };
        var list2 = new List<User> { user3, user2 };

        var result = _comparer.AreSequencesEqual(list1, list2);
        Assert.True(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnFalse_ForDifferentOrder()
    {
        var list1 = new List<User> { user1, user2 };
        var list2 = new List<User> { user2, user1 };

        var result = _comparer.AreSequencesEqual(list1, list2);
        Assert.False(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldHandleNullAsEmpty()
    {
        var list = new List<User> { user1 };
        Assert.False(_comparer.AreSequencesEqual(list, null));
        Assert.True(_comparer.AreSequencesEqual(null, null));
    }
}