using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class CourseRepo : EntityRepo<Course>, ICourseRepo
    {
        public CourseRepo(Context _context) : base(_context)
        {
        }
    }
}
