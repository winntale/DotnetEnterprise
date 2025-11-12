using static System.Console;

namespace OddFilter;

public class OddFilter
{
    public IEnumerable<int> GetOdd(ICollection<int> nums) => nums.Where(num => num % 2 != 0);

    public static void Main(string[] args)
    {
        List<int> nums = new() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        OddFilter oddFilter = new();
        WriteLine(string.Join(", ", oddFilter.GetOdd(nums)));
    }
}