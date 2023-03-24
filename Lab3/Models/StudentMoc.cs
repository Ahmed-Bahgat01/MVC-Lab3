namespace StudentDeptMemoCRUD.Models
{
    public class StudentMoc
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

        public void AddStudent(Student student)
        {
            studentsList.Add(student);
        }
        
        public Student? GetStudentById(int id)
        {
            return studentsList.FirstOrDefault(x => x.Id == id);
        }
        public void UpdateStudent(Student newStd)
        {
            Student? oldStd = studentsList.FirstOrDefault(a => a.Id == newStd.Id);
            if(oldStd is not null)
                oldStd.Name= newStd.Name;
        }

        public void DeleteStudent(int stdId)
        {
            Student? toBeRemovedStd = studentsList.FirstOrDefault(x => x.Id == stdId);
            if(toBeRemovedStd is not null)
                studentsList.Remove(toBeRemovedStd);
            
        }
    }
}
