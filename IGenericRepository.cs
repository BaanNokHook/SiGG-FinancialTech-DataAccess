using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GM.DataAccess.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] np);

        T GetByID(object id);

        void Insert(T e);

        void Delete(object id);

        void Delete(T eDlt);

        void Update(T eUpdt);

        void Save();

        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] np);
    }
}
