namespace FiltersApp.Models;

public class Employee : IEquatable<Employee>
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
    public required string Department { get; init; }
    public required string Email { get; init; }
    
    public bool Equals(Employee? other)
    {
        return other != null && Email == other.Email;
    }

    public override int GetHashCode() => Email.GetHashCode();
}

public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y) 
        => x?.Email == y?.Email;

    public int GetHashCode(Employee obj) 
        => obj.Email.GetHashCode();
}