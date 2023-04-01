using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public interface IStudentRepo : IEntityRepo<Student>
    {
        public Student? Update(Student student);
        public IEnumerable<Department> GetAllDepartments();
    }
}
