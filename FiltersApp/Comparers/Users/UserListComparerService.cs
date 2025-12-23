using FiltersApp.Models;

namespace FiltersApp.Comparers.Users;

internal sealed class UserListComparerService
{
    public bool AreSequencesEqual(ICollection<User>? firstList, ICollection<User>? secondList)
    {
        var first = firstList ?? [];
        var second = secondList ?? [];
        
        return first.SequenceEqual(second);
    }
}