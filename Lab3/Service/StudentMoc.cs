using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class StudentMoc : IStudent
    {
        private static List<Student> studentsList = new List<Student>()
        {
            new Student(1, "Ahmed"),
            new Student(2, "Bahgat")
        };

        public List<Student> StudentsList
        {
            get { return studentsList; }
        }
        private static List<Department> departmentsList = new List<Department>()
        {
            new Department(1, "mem1",250),
            new Department(2, "mem2", 450)
        };
        public List<Department> DepartmentsList
        {
            get { return departmentsList; }
        }

        public List<Department> GetAllDepartments()
        {
            return DepartmentsList;
        }
        public List<Student> GettAllStudents()
        {
            return StudentsList; //context.Students.ToList();
        }
        public void AddStudent(Student student)
        {
            //context.Students.Add(student);
            StudentsList.Add(student);
        }

        public Student? GetStudentById(int id)
        {
            //return context.Students.FirstOrDefault(x => x.Id == id);
            return StudentsList.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateStudent(Student newStd)
        {
            //Student? oldStd = context.Students.FirstOrDefault(a => a.Id == newStd.Id);
            Student? oldStd = StudentsList.FirstOrDefault(a => a.Id == newStd.Id);
            if (oldStd is not null)
                oldStd.Name = newStd.Name;
        }

        public void DeleteStudent(int stdId)
        {
            //Student? toBeRemovedStd = context.Students.FirstOrDefault(x => x.Id == stdId);
            Student? toBeRemovedStd = StudentsList.FirstOrDefault(x => x.Id == stdId);
            if (toBeRemovedStd is not null)
                StudentsList.Remove(toBeRemovedStd);

        }
    }
}
