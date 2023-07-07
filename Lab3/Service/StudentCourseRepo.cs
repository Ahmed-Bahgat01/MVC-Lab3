using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class StudentCourseRepo : EntityRepo<StudentCourse>, IStudentCourseRepo
    {
        public StudentCourseRepo(Context _context) : base(_context)
        {
        }

        public StudentCourse? GetById(int studentId, int courseId)
        {
            return context?.StudentCourses?.Find(studentId, courseId);
        }
    }
}
