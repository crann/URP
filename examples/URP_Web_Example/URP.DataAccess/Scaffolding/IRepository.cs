using System;
using System.Linq;
using System.Linq.Expressions;

namespace URP.DataAccess.Scaffolding
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void Update(T entity);
        int Count();
        int Count(Expression<Func<T, bool>> where);
        bool Any(Expression<Func<T, bool>> where);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
