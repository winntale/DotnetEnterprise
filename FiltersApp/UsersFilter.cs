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

    public Paginate<User> GetPaginateUsers(ICollection<User> users, int? skip, int? take)
    {
        var totalUsersCount = users.Count;
        var skipVal = skip ?? 0;
        var takeVal = take ?? 10;
        
        if (skipVal >= totalUsersCount || takeVal <= 0)
        {
            return new Paginate<User> { CurrentPageUsers = [], TotalCount = totalUsersCount };
        }
        
        var startIndex = skipVal * takeVal;
        
        var currentPageUsers = users
            .Skip(startIndex)
            .Take(takeVal)
            .ToList();
        
        return new Paginate<User> { CurrentPageUsers = currentPageUsers, TotalCount = totalUsersCount };
    }

    public ICollection<int> ReverseUserIds(ICollection<int>? userIds)
    {
        if (userIds == null)
        {
            return [];
        }
        return userIds
            .Reverse()
            .ToList();
    }

    public bool AllAdultUsers(ICollection<User>? users)
    {
        if (users == null)
        {
            return false;
        }

        return users
            .All(user => user.Age >= 18);
    }

    public bool AnyAdultUsers(ICollection<User>? users)
    {
        if (users == null)
        {
            return false;
        }

        return users
            .Any(user => user.Age >= 18);
    }

    public bool ContainsAdultUser(ICollection<User>? users)
    {
        if (users == null)
        {
            return false;
        }
        
        return users
            .Select(user => user.Age)
            .Contains(18);
    }

    public Dictionary<int, List<User>> GroupUsersByAge(ICollection<User> users)
    {
        return users
            .GroupBy(u => u.Age)
            .ToDictionary(
                grouping => grouping.Key,
                grouping => grouping.ToList()
            );
    }

    public ICollection<User> DistinctByIdUsers(ICollection<User> users)
    {
        return users
            .DistinctBy(u => u.Id)
            .ToList();
    }

    public ICollection<User> FindUsersWithSameName(ICollection<User> firstGroup, ICollection<User> secondGroup)
    {
        return firstGroup
            .IntersectBy(
                secondGroup.Select(u => u.Name),
                u => u.Name
            ).ToList();
    }

    public Dictionary<int, User> GroupByAgeUsingDictionary(ICollection<User> users)
    {
        return users.ToDictionary(
            u => u.Age,
            u => u);
    }

    public ILookup<int, User> GroupByAgeUsingLookup(ICollection<User> users)
    {
        return users.ToLookup(u => u.Age);
    }
    
    public HashSet<User> UniqueUsers(ICollection<User> users)
    {
        return users.ToHashSet();
    }

    public ICollection<User> AddUserAtEnd(
        ICollection<User> users,
        User newUser)
    {
        return users
            .Append(newUser)
            .ToList();
    }

    public ICollection<User> MergeUserCollections(
        ICollection<User> firstGroup,
        ICollection<User> secondGroup)
    {
        return firstGroup
            .Concat(secondGroup)
            .ToList();
    }

    public ICollection<User> AddUserAtBeginning(
        ICollection<User> users,
        User newUser)
    {
        return users
            .Prepend(newUser)
            .ToList();
    }
}