using FiltersApp.Models;

namespace FiltersApp;

public class StudentsFilter
{
    public List<(Student Student, List<Course> Courses)> GetStudentsWithCourses
    (
        ICollection<Student> students, ICollection<Course> courses
    )
    {
        return students
            .GroupJoin(
                courses,
                s => s.Id,
                c => c.StudentId,
                (s, c) => (Student: s, Courses: c.ToList() ))
            .ToList();
    }
}