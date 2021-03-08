using MiniEcommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MiniEcommerce.Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> AsQueryable();
        bool Any(Expression<Func<T, bool>> filter);

        T Get(Expression<Func<T, bool>> filter = null);

        T GetAsNoTracking(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);

        T Insert(T entity);
        void BulkInsert(List<T> entities);

        T Update(T entity);

        void Delete(T entity);
    }
}
