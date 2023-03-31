using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class DepartmentDB : IDepartment
    {
        //Context context = new Context();
        Context context;
        public DepartmentDB(Context _context)
        {
            context = _context;
        }



        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
        public void AddDepartment(Department newDepartment)
        {
            context.Departments.Add(newDepartment);
            context.SaveChanges();
        }

        public Department? GetDepartmentById(int id)
        {
            return context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDepartment(Department newDepartment)
        {
            Department? oldDept = context.Departments.FirstOrDefault(d => d.Id == newDepartment.Id);
            if (oldDept is not null)
            {
                oldDept.Name = newDepartment.Name;
                oldDept.Capacity = newDepartment.Capacity;
                context.SaveChanges();
            }
        }

        public void DeleteDepartment(int? id)
        {
            if (id is not null)
            {
                Department? toBeDelDept = context.Departments.FirstOrDefault(d => d.Id == id);
                if (toBeDelDept is not null)
                {
                    context.Departments.Remove(toBeDelDept);
                    context.SaveChanges();
                }
            }
        }
    }
}
