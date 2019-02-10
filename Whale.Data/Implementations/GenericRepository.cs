using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Whale.Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }

        private DbContext _context;
        private DbContext context
        {
            get
            {
                if (_context == null)
                {
                    _context = UnitOfWork.Context;
                }
                return _context;
            }
        }

        private IDbSet<T> _dbSet;
        private IDbSet<T> dbSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = UnitOfWork.Context.Set<T>();
                }
                return _dbSet;
            }
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public T GetById(int Id)
        {
            return dbSet.Find(Id);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public T GetByString(string query)
        {
            return dbSet.Where(query).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(query, parameters);
        }

        public void ExecSQLCommand(string query, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(query, parameters);
        }
    }
}
