using FiltersApp;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.StudentsTests;

public class GetStudentsWithCoursesTests
{
    private readonly StudentsFilter _studentsFilter = new();

    [Fact]
    public void GetStudentsWithCourses_ShouldReturnEmpty_WhenEmptyInput()
    {
        // Arrange
        ICollection<Student> students = [];
        ICollection<Course> courses = [];

        // Act
        var result = _studentsFilter.GetStudentsWithCourses(students, courses);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetStudentsWithCourses_ShouldReturnStudentsWithCourses_WhenCorrectInput()
    {
        // Arrange
        ICollection<Student> students = new List<Student>
        {
            new() { FullName = "Bazhal Aleksey", Id = Guid.NewGuid() },
            new() { FullName = "Dundukov Dunduk", Id = Guid.NewGuid() },
            new() { FullName = "Nerd Smart", Id = Guid.NewGuid() }
        };
        ICollection<Course> courses = new List<Course>
        {
            new()
            {
                Id = Guid.NewGuid(), StudentId = students.Single(s => s.FullName == "Bazhal Aleksey").Id,
                Title = "Guitar"
            },
            new()
            {
                Id = Guid.NewGuid(), StudentId = students.Single(s => s.FullName == "Bazhal Aleksey").Id,
                Title = "Photographing"
            },
            new()
            {
                Id = Guid.NewGuid(), StudentId = students.Single(s => s.FullName == "Nerd Smart").Id,
                Title = "Reading"
            }
        };

        var expectingResult = new List<(Student Student, List<Course> Courses)>
        {
            (
                students.Single(s => s.FullName == "Bazhal Aleksey"),
                [
                    courses.Single(c => c.Title == "Guitar"),
                    courses.Single(c => c.Title == "Photographing")
                ]
            ),
            (
                students.Single(s => s.FullName == "Dundukov Dunduk"),
                []
            ),
            (
                students.Single(s => s.FullName == "Nerd Smart"),
                [ courses.Single(c => c.Title == "Reading") ]
            )
        };
        // Act
        var result = _studentsFilter.GetStudentsWithCourses(students, courses);

        // Assert
        var firstExp = expectingResult[0];
        var firstAct = result.Single(r => r.Student.FullName == "Bazhal Aleksey");
        Assert.Equal(firstExp.Student.FullName, firstAct.Student.FullName);
        Assert.Equal(firstExp.Courses[0].Title, firstAct.Courses[0].Title);
        Assert.Equal(firstExp.Courses[1].Title, firstAct.Courses[1].Title);

        var secondExp = expectingResult[1];
        var secondAct = result.Single(r => r.Student.FullName == "Dundukov Dunduk");
        Assert.Equal(secondExp.Student.FullName, secondAct.Student.FullName);
        Assert.Empty(secondAct.Courses);

        var thirdExp = expectingResult[2];
        var thirdAct = result.Single(r => r.Student.FullName == "Nerd Smart");
        Assert.Equal(thirdExp.Courses[0].Title, thirdAct.Courses[0].Title);
    }
}