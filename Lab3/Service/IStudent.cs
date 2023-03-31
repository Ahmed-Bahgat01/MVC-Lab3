using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public interface IStudent
    {
        // apply dependency injection for student also
        public List<Student> GettAllStudents();
        public void AddStudent(Student student);
        public Student? GetStudentById(int id);
        public void UpdateStudent(Student newStd);
        public void DeleteStudent(int stdId);
        public List<Department> GetAllDepartments();
    }
}
