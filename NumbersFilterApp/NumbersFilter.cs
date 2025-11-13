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

    public static void Main(string[] args)
    {
        NumbersFilter numbersFilter = new();
        
        // odd
        List<int> nums = new() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        WriteLine(string.Join(", ", numbersFilter.GetOdd(nums)));
        
        // positive
        ICollection<int> numbers = new List<int> { 1, -2, 3, -4, 2, -6, 4, -8, 1 };
        WriteLine(string.Join(", ", numbersFilter.GetPositiveNumbers(numbers)));
    }
}