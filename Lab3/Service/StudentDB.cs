using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class StudentDB : IStudent
    {
        //private Context context = new Context();
        private Context context;
        public StudentDB(Context _context)
        {
            context= _context;
        }

        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
        public List<Student> GettAllStudents()
        {
            return context.Students.ToList();
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateStudent(Student newStd)
        {
            Student? oldStd = context.Students.FirstOrDefault(a => a.Id == newStd.Id);
            if (oldStd is not null)
                oldStd.Name = newStd.Name;
            context.SaveChanges();
        }

        public void DeleteStudent(int stdId)
        {
            Student? toBeRemovedStd = context.Students.FirstOrDefault(x => x.Id == stdId);
            if (toBeRemovedStd is not null)
            {
                context.Students.Remove(toBeRemovedStd);
                context.SaveChanges();
            }
        }
    }
}
