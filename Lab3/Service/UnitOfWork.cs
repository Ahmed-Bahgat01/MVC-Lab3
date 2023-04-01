using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context context;

        public IDepartmentRepo Departments { get; private set; }
        public IStudentRepo Students { get; private set; }
        public ICourseRepo Courses { get; private set; }
        public UnitOfWork(Context _context)
        {
            context = _context;
            Departments = new DepartmentRepo(_context);
            Students = new StudentRepo(_context);
            Courses = new CourseRepo(_context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
