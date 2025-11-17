using static System.Console;

namespace NumbersFilter;

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

    public static void Main(string[] args)
    {
        NumbersFilter numbersFilter = new();
        
        // init
        ICollection<int> numbers = new List<int> { 1, -2, 3, -4, 2, -5, 4, -3, 5 };
        WriteLine("Initial input: " + string.Join(", ", numbers));
        
        // odd
        WriteLine("Odds: " + string.Join(", ", numbersFilter.GetOdd(numbers)));
        
        // positive
        WriteLine("Positive nums: " + string.Join(", ", numbersFilter.GetPositiveNumbers(numbers)));
        
        // first odd
        WriteLine("First odd: " + numbersFilter.GetFirstOddNumber(numbers));
        
        // last odd
        WriteLine("Last odd: " + numbersFilter.GetLastOddNumber(numbers));
        
        // single odd
        WriteLine("Single odd: " + numbersFilter.GetSingleOddNumber(numbers));
    }
}