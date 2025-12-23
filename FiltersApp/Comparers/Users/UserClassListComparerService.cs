using FiltersApp.Models;

namespace FiltersApp.Comparers.Users;

internal sealed class UserClassListComparerService
{
    public bool AreSequencesEqual(ICollection<UserClass>? firstList, ICollection<UserClass>? secondList)
    {
        var first = firstList ?? [];
        var second = secondList ?? [];

        return first.SequenceEqual(second);
    }
}