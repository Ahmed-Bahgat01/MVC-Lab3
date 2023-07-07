using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Service
{
    public class EntityRepo<T> : IEntityRepo<T> where T : class
    {
        protected readonly Context context;
        public EntityRepo(Context _context)
        {
            context= _context;
        }
        public void Add(T? entity)
        {
            if(entity is not null){
                context.Set<T>().Add(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Remove(T? entity)
        {
            if(entity is not null)
            {
                context.Set<T>().Remove(entity);
            }
        }
        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    context.Dispose();
        //}

        //public void Update(T entity)
        //{
        //    context.Set<T>().Update(entity);
        //}
    }
}
