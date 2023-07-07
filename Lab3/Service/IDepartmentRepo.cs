using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public interface IDepartmentRepo : IEntityRepo<Department>
    {
        public Department? Update(Department? department);
        public IEnumerable<Course>? GetAllCourses();
    }
}
