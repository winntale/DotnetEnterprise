using FiltersApp.Models;
using FiltersApp.UsersAPI;
using Moq;
using NumbersFilterTests.Fixtures;
using Xunit;

namespace NumbersFilterTests.UsersAPITests;

public class UserBatchProcessorTests
{
    private List<User> GenerateUsers(int count)
    {
        return Enumerable.Range(0, count)
            .Select(i => new User
            {
                Id = Guid.NewGuid(),
                Age = 20 + (i % 60),
                Name = $"User{i:D3}"
            })
            .ToList();
    }
    
    [Fact]
    public async Task ProcessUsersInBatches_ShouldReturnZeroStats_WhenEmptyInput()
    {
        // Arrange
        var users = new List<User>();
        var expected = new BatchProcessingResult(0, 0, 0, 0);
        
        // Act
        var result = await UserBatchProcessorFixture.Processor.ProcessUsersInBatches(users);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public async Task ProcessUsersInBatches_ShouldCountTwoBatches_WhenSixUsers()
    {
        // Arrange
        UserBatchProcessorFixture.MockApiClient
            .SetupSequence(x => x.SendUsersBatchAsync(It.IsAny<IEnumerable<User>>()))
            .ReturnsAsync(true)
            .ReturnsAsync(true);
            
        var expected = new BatchProcessingResult(6, 2, 2, 0);
        
        // Act
        var result = await UserBatchProcessorFixture.Processor.ProcessUsersInBatches(GenerateUsers(6));
        
        // Assert
        Assert.Equal(expected, result);
    }
}



