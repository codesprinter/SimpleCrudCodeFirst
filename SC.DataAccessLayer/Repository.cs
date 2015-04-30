using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using SC.DomainLayer;

namespace SC.DataAccessLayer
{
    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
    }

    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        DbContext _context;
        public GenericDataRepository(DbContext context)
        {
            if (context == null) {
                throw new ArgumentNullException("context");
            }
            _context = context;
        }
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            //using (var context = new Entities()) {
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .ToList<T>();
            //}
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            //using (var context = new Entities()) {
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            //}
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            //using (var context = new Entities()) {
            IQueryable<T> dbQuery = _context.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .AsNoTracking() //Don't track any changes for the selected item
                .FirstOrDefault(where); //Apply where clause
            //}
            return item;
        }

        /* rest of code omitted */
        public virtual void Add(params T[] items)
        {
            Update(items);
        }

        public virtual void Update(params T[] items)
        {
            DbSet<T> dbSet = _context.Set<T>();
            foreach (T item in items) {
                dbSet.Add(item);
                foreach (DbEntityEntry<IEntity> entry in _context.ChangeTracker.Entries<IEntity>()) {
                    IEntity entity = entry.Entity;
                    entry.State = GetEntityState(entity.EntityState);
                }
            }
 
        }

        public virtual void Remove(params T[] items)
        {
            Update(items);
        }
        protected static System.Data.Entity.EntityState GetEntityState(SC.DomainLayer.EntityState entityState)
        {
            switch (entityState) {
                case DomainLayer.EntityState.Unchanged:
                    return System.Data.Entity.EntityState.Unchanged;
                case DomainLayer.EntityState.Added:
                    return System.Data.Entity.EntityState.Added;
                case DomainLayer.EntityState.Modified:
                    return System.Data.Entity.EntityState.Modified;
                case DomainLayer.EntityState.Deleted:
                    return System.Data.Entity.EntityState.Deleted;
                default:
                    return System.Data.Entity.EntityState.Detached;
            }
        }
    }
}
