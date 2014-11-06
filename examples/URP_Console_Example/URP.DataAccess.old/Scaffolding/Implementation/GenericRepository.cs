using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace URP.DataAccess.Scaffolding.Implementation
{
    /// <summary>
    /// Provides standard CRUD functionality on the database.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext dataContext;
        protected readonly IDbSet<T> dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        public GenericRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        /// <summary>
        /// Gets or sets the database factory.
        /// </summary>
        /// <value>The database factory.</value>
        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>The data context.</value>
        protected ApplicationContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual T Add(T entity)
        {
            return dbset.Add(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        /// <summary>
        /// Counts all instances of the entity.
        /// </summary>
        public virtual int Count()
        {
            return dbset.Count();
        }

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbset.Count(where);
        }

        /// <summary>
        /// Checks whether any records match the expression.
        /// </summary>
        /// <param name="where">The where.</param>
        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return dbset.Any(where);
        }

        /// <summary>
        /// Deletes the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return dbset;
        }

        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where);
        }

        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
