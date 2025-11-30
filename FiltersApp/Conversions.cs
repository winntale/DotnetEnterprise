namespace FiltersApp;

public class Conversions
{
    public ICollection<long> CastIntToLong(ICollection<int> list)
    {
        return list
            .Select(i => (long)i)
            .ToList();
    }
}