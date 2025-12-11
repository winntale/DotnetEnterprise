using FiltersApp.Models;

namespace FiltersApp;

public class EmployeeFilter
{
    public List<Employee> GetCombinedTeamUnion(List<Employee> teamA, List<Employee> teamB)
    {
        return teamA
            .Union(teamB)
            .ToList();
    }

    public List<Employee> GetCombinedTeamUnionBy(List<Employee> teamA, List<Employee> teamB)
    {
        return teamA
            .UnionBy(teamB, e => e.Email)
            .ToList();
    }

    public List<Employee> GetCombinedTeamUnionWithComparer(List<Employee> teamA, List<Employee> teamB)
    {
        return teamA
            .Union(teamB, new EmployeeComparer())
            .ToList();
    }
}