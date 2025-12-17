using FiltersApp.Models;

namespace FiltersApp.UsersAPI;

internal sealed class AggregateUsers
{
    public int CountUsers(ICollection<User> users)
    {
        return users.Count();
    }

    public int GetMaxAge(ICollection<User> users)
    {
        return users.Max(u => u.Age);
    }

    public int GetMinAge(ICollection<User> users)
    {
        return users.Min(u => u.Age);
    }

    public int SumAges(ICollection<User> users)
    {
        return users.Sum(u => u.Age);
    }
}