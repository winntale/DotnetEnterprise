namespace FiltersApp;


internal sealed class SumService
{
    public int SumCalculate(int[] nums)
    {
        return nums.Aggregate(0, (acc, cur) => acc + cur);
    }
}