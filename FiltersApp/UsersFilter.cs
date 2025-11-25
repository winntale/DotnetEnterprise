using FiltersApp.Models;

namespace FiltersApp;

public class UsersFilter
{
    public ICollection<Guid> SelectUserIds(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        return users.Where(user => user.Age > age).Select(user => user.Id).ToList();
    }

    public ICollection<User> SelectUsers(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        return users
            .Where(user => user.Age > age)
            .OrderBy(user => user.Age)
            .ThenBy(user => user.Name)
            .ToList();
    }
    
    public ICollection<User> DescendingAgeUsers(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        return users
            .Where(user => user.Age > age)
            .OrderByDescending(user => user.Age)
            .ThenBy(user => user.Name)
            .ToList();
    }

    public ICollection<Project> SelectUserProjects(ICollection<User>? users, int age)
    {
        if (users == null)
        {
            return [];
        }
        return users
            .Where(user => user.Age > age)
            .SelectMany(user => user.Projects ?? Enumerable.Empty<Project>())
            .ToList();
    }
}