using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Whale.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int Id);
        T GetByString(string query);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
        void ExecSQLCommand(string query, params object[] parameters);
    }
}
