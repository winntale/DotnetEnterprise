using FiltersApp.Models;

namespace FiltersApp.Comparers.Users;

public class UserNameComparer : IEqualityComparer<User>
{
    public bool Equals(User? x, User? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null || y is null) return false;

        return x.Name == y.Name;
    }

    public int GetHashCode(User obj)
    {
        return obj.Name is not null ? obj.Name.GetHashCode() : 0;
    }
}