using static System.Console;

namespace FiltersApp;

public class NumbersFilter
{
    public IEnumerable<int> GetOdd(ICollection<int>? nums)
    {
        if (nums == null)
        {
            return new List<int>();
        }
        return nums.Where(num => num % 2 != 0);
    }

    public ICollection<int> GetPositiveNumbers(ICollection<int>? nums)
    {
        if (nums == null)
        {
            return new List<int>();
        }
        return nums.Where(n => n > 0).ToList();
    }

    public int? GetFirstOddNumber(ICollection<int>? numbers)
    {
        var result = numbers?.FirstOrDefault(n => n % 2 != 0);
        
        if (result == 0)
        {
            return null;
        }
        return result;
    }

    public int? GetLastOddNumber(ICollection<int>? numbers)
    {
        var result = numbers?.LastOrDefault(n => n % 2 != 0);

        if (result == 0)
        {
            return null;
        }
        return result;
    }

    public int? GetSingleOddNumber(ICollection<int>? numbers)
    {
        return numbers?.SingleOrDefault(n => n % 2 != 0);
    }

    public int? GetElementAtOrDefault(ICollection<int>? collection, int index)
    {
        return collection?.ElementAtOrDefault(index);
    }
}