using Xunit;
using FiltersApp;
using FiltersApp.Models;

namespace NumbersFilterTests.UsersTests;

public class SelectUserProjectsTests
{
    private readonly UsersFilter _filter = new();

    [Fact]
    public void SelectUsersProject_ShouldReturnEmpty_WhenNullInput()
    {
        // Arrange
        ICollection<User>? users = null;

        // Act
        var result = _filter.SelectUserProjects(users, 20);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SelectUsersProject_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<User> users = [];

        // Act
        var result = _filter.SelectUserProjects(users, 20);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void SelectUsersProject_ShouldReturnProjects_WhenCorrectInput()
    {
        // Arrange
        IList<Project> alekseysProjects = new List<Project>
        {
            new() { Id = Guid.NewGuid(), Name = "WeatherApp" },
            new() { Id = Guid.NewGuid(), Name = "WeatherV2" },
            new() { Id = Guid.NewGuid(), Name = "ToDoList" }
        };
        IList<Project> robertsProjects = new List<Project>
        {
            new() { Id = Guid.NewGuid(), Name = "RobertProject" },
            new() { Id = Guid.NewGuid(), Name = "GymApp" }
        };
        IList<Project> elenasProjects = new List<Project>
        {
            new() { Id = Guid.NewGuid(), Name = "Lab1" },
            new() { Id = Guid.NewGuid(), Name = "Lab2" }
        };
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 23, Projects = alekseysProjects },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 43, Projects = robertsProjects },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17, Projects = elenasProjects }
        };
        var expectingResult = new List<Project> {
            alekseysProjects[0], alekseysProjects[1], alekseysProjects[2],
            robertsProjects[0], robertsProjects[1]
        }; 
        
        // Act
        var result = _filter.SelectUserProjects(users, 20);
        
        // Assert
        Assert.Equal(expectingResult, result);
    }

    [Fact]
    public void SelectUsersProject_ShouldReturnEmpty_WhenNoProjects()
    {
        // Arrange
        ICollection<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid(), Name = "Aleksey", Age = 23, Projects = [] },
            new() { Id = Guid.NewGuid(), Name = "Robert", Age = 43, Projects = [] },
            new() { Id = Guid.NewGuid(), Name = "Elena", Age = 17, Projects = [] }
        };
        
        // Act
        var result = _filter.SelectUserProjects(users, 20);
        
        // Assert
        Assert.Empty(result);
    }
}