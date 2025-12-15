namespace FiltersApp;

public class Aggregations
{
    public sealed class SumService
    {
        public int SumCalculate(int[] nums)
        {
            return nums.Aggregate((acc, cur) => acc + cur);
        }
    }
}