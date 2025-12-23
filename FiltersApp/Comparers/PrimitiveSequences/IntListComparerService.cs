namespace FiltersApp.Comparers.PrimitiveSequences;

internal sealed class IntListComparerService
{
    public bool AreSequencesEqual(ICollection<int>? firstList, ICollection<int>? secondList)
    {
        var first = firstList ?? [];
        var second = secondList ?? [];

        return first.SequenceEqual(second);
    }
}