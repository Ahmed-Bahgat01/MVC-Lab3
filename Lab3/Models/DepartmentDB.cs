using StudentDeptMemoCRUD.Service;

namespace StudentDeptMemoCRUD.Models
{
    public class DepartmentDB:IDepartment
    {
        Context _context = new Context();
        


        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
        public void AddDepartment(Department newDepartment)
        {
            _context.Departments.Add(newDepartment);
            _context.SaveChanges();
        }

        public Department? GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDepartment(Department newDepartment)
        {
            Department? oldDept = _context.Departments.FirstOrDefault(d => d.Id == newDepartment.Id);
            if (oldDept is not null)
            {
                oldDept.Name = newDepartment.Name;
                oldDept.Capacity = newDepartment.Capacity;
                _context.SaveChanges();
            }
        }

        public void DeleteDepartment(int? id)
        {
            if (id is not null)
            {
                Department? toBeDelDept = _context.Departments.FirstOrDefault(d => d.Id == id);
                if (toBeDelDept is not null)
                {
                    _context.Departments.Remove(toBeDelDept);
                    _context.SaveChanges();
                }
            }
        }
    }
}
