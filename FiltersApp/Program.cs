using System.Runtime.CompilerServices;
using static System.Console;
using FiltersApp.Models;

[assembly: InternalsVisibleTo("FiltersTests")]

namespace FiltersApp;

public static class Program
{
    public static void Main(string[] args)
    {
        // NUMBERS BLOCK
        // init
        NumbersFilter numbersFilter = new();
        ICollection<int> numbers = new List<int> { 1, -2, 3, -4, 2, -5, 4, -3, 5 };
        WriteLine("Initial input: " + string.Join(", ", numbers));
        
        // odd
        WriteLine("Odds: " + string.Join(", ", numbersFilter.GetOdd(numbers)));
        
        // positive
        WriteLine("Positive nums: " + string.Join(", ", numbersFilter.GetPositiveNumbers(numbers)));
        
        // first odd
        WriteLine("First odd: " + numbersFilter.GetFirstOddNumber(numbers));
        
        // last odd
        WriteLine("Last odd: " + numbersFilter.GetLastOddNumber(numbers));
        
        // single odd (exception occurs)
        //WriteLine("Single odd: " + numbersFilter.GetSingleOddNumber(numbers));
        
        // element at index
        WriteLine("Element at index 1: " + numbersFilter.GetElementAtOrDefault(numbers, 1));
        
        
        // USERS BLOCK
        UsersFilter usersFilter = new();
        var users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 20 },
            new() { Id = Guid.NewGuid(), Name = "John", Age = 21 },
            new() { Id = Guid.NewGuid(), Name = "Jane", Age = 17 },
            new() { Id = Guid.NewGuid(), Name = "James", Age = 23 },
            new() { Id = Guid.NewGuid(), Name = "Barbara", Age = 15 }
        };
        WriteLine("Input users: " + string.Join(", ", users.Select(u => (u.Id, u.Age))));
        
        // user ids for users which age is more than an `age` parameter
        WriteLine("Ids of users that older than 20: " + string.Join(", ", usersFilter.SelectUserIds(users, 20)));
        
        // users that age is more than an `age` parameter, sorted descending by age
        WriteLine("Sorted by age users that older than 20: " + string.Join(", ", usersFilter.SelectUsers(users, 20)));

        // 2nd page of users, taken by 2 elements which
        var paginateUsers = usersFilter.GetPaginateUsers(users, 1, 2);
        WriteLine("Paginate: " + string.Join(", ", paginateUsers.CurrentPageUsers)
                               + " total count: " + paginateUsers.TotalCount);
        
        // reversed ids
        var userIds = new List<int> { 1, 2, 3, 4, 5 };
        WriteLine("Input users: " + string.Join(", ", usersFilter.ReverseUserIds(userIds)));
        
        
        // CONVERSIONS BLOCK
        Conversions conversions = new();
        
        var list = new List<int> { 1, 2, 3, 4, 5 };
        WriteLine("List of longs: " + string.Join(", ", conversions.CastIntToLong(list)));
    }
}