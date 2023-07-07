using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public interface IStudentCourseRepo : IEntityRepo<StudentCourse>
    {
        StudentCourse? GetById(int studentId, int courseId);
    }
}
