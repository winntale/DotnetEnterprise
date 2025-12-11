using FiltersApp;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.EmployeeTests;

public class GetCombinedTeamUnion
{
    private readonly EmployeeFilter _employeeFilter = new();
    
    private static readonly Employee EmployeeA1 = new()
    {
        Id = Guid.NewGuid(),
        FullName = "Иван Иванов",
        Department = "IT",
        Email = "ivan@company.com"
    };

    private static readonly Employee EmployeeA2 = new()
    {
        Id = Guid.NewGuid(), 
        FullName = "Иван Иванов",
        Department = "IT",
        Email = "olga@company.com"
    };

    private static readonly Employee EmployeeB1 = new()
    {
        Id = Guid.NewGuid(),
        FullName = "Иван Иванов (совместитель)",
        Department = "HR", 
        Email = "ivan@company.com"
    };

    private static readonly Employee EmployeeB2 = new()
    {
        Id = Guid.NewGuid(),
        FullName = "Петр Петров",
        Department = "HR",
        Email = "petr@company.com"
    };
    
    [Fact]
    public void GetCombinedTeamUnion_ShouldReturnEmpty_WhenBothInputsEmpty()
    {
        // Arrange
        var teamA = new List<Employee>();
        var teamB = new List<Employee>();
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnion(teamA, teamB);
    
        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetCombinedTeamUnion_ShouldRemoveDuplicatesByEmail_WhenSharedEmployees()
    {
        // Arrange
        var teamA = new List<Employee> { EmployeeA1, EmployeeA2 };
        var teamB = new List<Employee> { EmployeeB1, EmployeeB2 };
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnion(teamA, teamB);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Contains(result, e => e.Email == "ivan@company.com");
        Assert.Single(result, e => e.Email == "ivan@company.com");
    }

    [Fact]
    public void GetCombinedTeamUnion_ShouldReturnAllUnique_WhenNoOverlap()
    {
        // Arrange
        var teamA = new List<Employee> { EmployeeA1 };
        var teamB = new List<Employee> { EmployeeB2 };
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnion(teamA, teamB);
    
        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetCombinedTeamUnionBy_ShouldRemoveDuplicatesByEmailKey_WhenSharedEmployees()
    {
        // Arrange
        var teamA = new List<Employee> { EmployeeA1, EmployeeA2 };
        var teamB = new List<Employee> { EmployeeB1, EmployeeB2 };
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnionBy(teamA, teamB);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Single(result, e => e.Email == "ivan@company.com");
    }

    [Fact]
    public void GetCombinedTeamUnionBy_ShouldPreserveFirstOccurrence_WhenDuplicateEmails()
    {
        // Arrange
        var teamA = new List<Employee> { EmployeeA1 };
        var teamB = new List<Employee> { EmployeeB1 };
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnionBy(teamA, teamB);
    
        // Assert
        Assert.Single(result);
        Assert.Equal("IT", result.First().Department);
    }
    
    [Fact]
    public void GetCombinedTeamUnionWithComparer_ShouldRemoveDuplicatesUsingComparer_WhenSharedEmployees()
    {
        // Arrange
        var teamA = new List<Employee> { EmployeeA1, EmployeeA2 };
        var teamB = new List<Employee> { EmployeeB1, EmployeeB2 };
    
        // Act
        var result = _employeeFilter.GetCombinedTeamUnionWithComparer(teamA, teamB);
    
        // Assert
        Assert.Equal(3, result.Count);
        Assert.Single(result, e => e.Email == "ivan@company.com");
    }
}