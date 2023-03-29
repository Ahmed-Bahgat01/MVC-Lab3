using StudentDeptMemoCRUD.Service;

namespace StudentDeptMemoCRUD.Models
{
    public class DepartmentMoc: IDepartment
    {
        private static List<Department> Departments = new List<Department>()
        {
            new Department(1, "IT", 20),
            new Department(2, "Sales", 40),
            new Department(3, "R&D", 10)
        };
        //public List<Department>? Departments {
        //    get { return departments; }
        //    set 
        //    { 
        //        if(departments is null && value is not null)
        //            departments = value;
        //    }
        //}

        public List<Department> GetAllDepartments()
        {
            return Departments;
        }

        public void AddDepartment(Department newDepartment)
        {
            Departments ??= new List<Department>();
            Departments?.Add(newDepartment);
        }

        public Department? GetDepartmentById(int id)
        {
            return Departments?.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateDepartment(Department newDepartment)
        {
            Department? oldDept = Departments?.FirstOrDefault(d=>d.Id == newDepartment.Id);
            if(oldDept is not null)
            {
                oldDept.Name= newDepartment.Name;
                oldDept.Capacity= newDepartment.Capacity;
            }
        }

        public void DeleteDepartment(int? id)
        {
            if(id is not null)
            {
                Department? toBeDelDept = Departments?.FirstOrDefault(d=> d.Id == id);
                if(toBeDelDept is not null)
                    Departments.Remove(toBeDelDept);
            }
        }
    }
}
