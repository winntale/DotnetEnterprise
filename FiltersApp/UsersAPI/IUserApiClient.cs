using FiltersApp.Models;

namespace FiltersApp.UsersAPI;

public interface IUserApiClient
{
    Task<bool> SendUsersBatchAsync(IEnumerable<User> users);
}