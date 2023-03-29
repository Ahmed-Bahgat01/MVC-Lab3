using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public interface IDepartment
    {
        public List<Department> GetAllDepartments();
        public void AddDepartment(Department newDepartment);
        public Department? GetDepartmentById(int id);
        public void UpdateDepartment(Department newDepartment);
        public void DeleteDepartment(int? id);
    }
}
