namespace StudentDeptMemoCRUD.Service
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentRepo Departments { get; }
        IStudentRepo Students { get; }
        int Save();
    }
}
