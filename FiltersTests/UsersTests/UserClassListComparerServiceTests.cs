using FiltersApp.Comparers.Users;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.UsersTests;

public class UserClassListComparerServiceTests
{
    private readonly UserClassListComparerService _comparer = new();
    private static readonly UserClass user1 = new() { Id = Guid.NewGuid(), Age = 25 };
    private readonly UserClass user2 = new() { Id = Guid.NewGuid(), Age = 30 };
    private readonly UserClass user3 = new() { Id = user1.Id, Age = 25 };

    [Fact]
    public void AreSequencesEqual_ShouldReturnFalse_ForDifferentInstances()
    {
        var list1 = new List<UserClass> { user1, user2 };
        var list2 = new List<UserClass> { user3, user2 };

        var result = _comparer.AreSequencesEqual(list1, list2);
        Assert.False(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnTrue_ForSameInstances()
    {
        var list1 = new List<UserClass> { user1, user2 };
        var list2 = new List<UserClass> { user1, user2 };

        var result = _comparer.AreSequencesEqual(list1, list2);
        Assert.True(result);
    }
}