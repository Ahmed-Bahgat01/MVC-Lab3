namespace StudentDeptMemoCRUD.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepo Departments { get; }
        IStudentRepo Students { get; }
        ICourseRepo Courses { get; }
        IStudentCourseRepo StudentCourses { get; }
        int Save();
    }
}
