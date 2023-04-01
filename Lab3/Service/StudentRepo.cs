using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class StudentRepo : EntityRepo<Student>, IStudentRepo
    {
        public StudentRepo(Context _context) : base(_context)
        {
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }

        /// <summary>
        ///     this method searches for student by Id updates all it's values
        /// </summary>
        /// <param name="newStudent"></param>
        /// <returns>
        ///     Student : new updated student
        ///     null : if student not found
        /// </returns>
        public Student? Update(Student newStudent)
        {
            Student? toBeUpdated = GetById(newStudent.Id);
            if(toBeUpdated != null)
            {
                toBeUpdated.Name = newStudent.Name;
                toBeUpdated.DepartmentId = newStudent.DepartmentId;
            }
            return toBeUpdated;
        }
    }
}
