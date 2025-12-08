using FiltersApp.Models;

namespace FiltersApp.UsersAPI;

public class UserBatchProcessor(IUserApiClient apiClient, int batchSize = 100)
{
    private readonly IUserApiClient _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    private readonly int _batchSize = batchSize > 0
        ? batchSize 
        : throw new ArgumentException("batchsize должен быть положительным");

    public async Task<BatchProcessingResult> ProcessUsersInBatches(ICollection<User> allUsers)
    {
        var totalUsers = allUsers.Count;
        if (totalUsers == 0) return new BatchProcessingResult(0, 0, 0, 0);

        var batches = allUsers.Chunk(_batchSize);
        var totalBatches = batches.Count();

        var successfulBatches = 0;
        var failedBatches = 0;
        
        foreach (var batch in batches)
        {
            try
            {
                var success = await _apiClient.SendUsersBatchAsync(batch);
                if (success) successfulBatches++;
                else failedBatches++;
            }
            catch
            {
                failedBatches++;
            }
        }

        return new BatchProcessingResult(totalUsers, totalBatches, successfulBatches, failedBatches);
    }
}