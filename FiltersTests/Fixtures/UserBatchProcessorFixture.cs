using FiltersApp.UsersAPI;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace NumbersFilterTests.Fixtures;

internal sealed class UserBatchProcessorFixture
{
    private static readonly int _batchSize = 3;
    private static IServiceProvider ServiceProvider { get; set; }
    internal static Mock<IUserApiClient> MockApiClient { get; private set; }
    internal static UserBatchProcessor Processor => ServiceProvider.CreateScope().ServiceProvider.GetRequiredService<UserBatchProcessor>();

    static UserBatchProcessorFixture()
    {
        MockApiClient = new Mock<IUserApiClient>();
        var services = new ServiceCollection();
        services.AddSingleton<IUserApiClient>(MockApiClient.Object);
        services.AddScoped<UserBatchProcessor>(sp =>
            new UserBatchProcessor(MockApiClient.Object, batchSize: _batchSize));
        
        ServiceProvider = services.BuildServiceProvider();
    }
}



