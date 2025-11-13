using static System.Console;

namespace PositiveFilter;
public class PositiveFilter
{
    public ICollection<int> GetPositiveNumbers(ICollection<int>? numbers)
    {
        if (numbers == null) return new List<int>();
        return numbers.Where(n => n > 0).ToList();
    }

    public static void Main(string[] args)
    {
        ICollection<int> numbers = new List<int> { 1, -2, 3, -4, 2, -6, 4, -8, 1 };
        PositiveFilter positiveFilter = new();
        positiveFilter.GetPositiveNumbers(numbers);
        WriteLine(string.Join(", ", positiveFilter.GetPositiveNumbers(numbers)));
    }
}