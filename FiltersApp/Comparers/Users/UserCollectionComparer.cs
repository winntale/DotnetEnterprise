using FiltersApp.Models;

namespace FiltersApp.Comparers.Users;

internal sealed class UserCollectionComparer
{
    public bool AreCollectionsEqual(
        ICollection<User>? first,
        ICollection<User>? second)
    {
        var firstList = first ?? [];
        var secondList = second ?? [];

        return firstList.SequenceEqual(secondList);
    }

    public bool AreCollectionsEqual(
        ICollection<User>? first,
        ICollection<User>? second, 
        IEqualityComparer<User>? comparer)
    {
        var firstList = first ?? [];
        var secondList = second ?? [];

        return comparer is null 
            ? firstList.SequenceEqual(secondList)
            : firstList.SequenceEqual(secondList, comparer);
    }
}