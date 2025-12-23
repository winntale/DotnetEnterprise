using System.Collections.Generic;
using System.Linq;
using FiltersApp.Comparers.PrimitiveSequences;
using Xunit;

namespace NumbersFilterTests.NumbersTests;

public class IntListComparerServiceTests
{
    private readonly IntListComparerService _comparer = new();

    [Fact]
    public void AreSequencesEqual_ShouldReturnFalse_ForDifferentLengths()
    {
        var list1 = Enumerable.Range(0, 100).ToList();
        var list2 = Enumerable.Range(0, 90).ToList();

        var result = _comparer.AreSequencesEqual(list1, list2);

        Assert.False(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnTrue_ForIdenticalLists()
    {
        var list1 = Enumerable.Range(0, 5).ToList();
        var list2 = Enumerable.Range(0, 5).ToList();

        var result = _comparer.AreSequencesEqual(list1, list2);

        Assert.True(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnFalse_ForDifferentOrder()
    {
        var list1 = new List<int> { 1, 2, 3 };
        var list2 = new List<int> { 3, 2, 1 };

        var result = _comparer.AreSequencesEqual(list1, list2);

        Assert.False(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnTrue_ForTwoEmpty()
    {
        var result = _comparer.AreSequencesEqual([], []);

        Assert.True(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldReturnFalse_ForEmptyVsNonEmpty()
    {
        var list = new List<int> { 1, 2, 3 };
        var result = _comparer.AreSequencesEqual([], list);

        Assert.False(result);
    }

    [Fact]
    public void AreSequencesEqual_ShouldTreatNullAsEmpty()
    {
        var list = new List<int> { 1, 2, 3 };
        
        Assert.True(_comparer.AreSequencesEqual(null, null));
        Assert.True(_comparer.AreSequencesEqual([], null));
        Assert.False(_comparer.AreSequencesEqual(list, null));
    }
}
