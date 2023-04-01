using System.Linq.Expressions;

namespace StudentDeptMemoCRUD.Service
{
    public interface IEntityRepo<T> : IDisposable
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        //IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T? entity);
        void Remove(T? entity);
        void Save();
        //void Update(T entity);
    }
}
