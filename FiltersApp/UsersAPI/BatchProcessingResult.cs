namespace FiltersApp.UsersAPI;

public record BatchProcessingResult
{
    public int TotalUsers { get; init; }
    public int TotalBatches { get; init; }
    public int SuccessfulBatches { get; init; }
    public int FailedBatches { get; init; }

    public BatchProcessingResult(int totalUsers, int totalBatches, int successfulBatches, int failedBatches)
    {
        TotalUsers = totalUsers;
        TotalBatches = totalBatches;
        SuccessfulBatches = successfulBatches;
        FailedBatches = failedBatches;
    }
    

    public override int GetHashCode()
    {
        return HashCode.Combine(TotalUsers, TotalBatches, SuccessfulBatches, FailedBatches);
    }
}