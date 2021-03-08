using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Core.DataAccess.Abstract;
using MiniEcommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MiniEcommerce.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        public readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Any(filter);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }

        public TEntity GetAsNoTracking(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.AsNoTracking().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbSet.ToList() : _dbSet.Where(filter).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            entity.CreatedTime = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public void BulkInsert(List<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            _context.SaveChanges();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedTime = DateTime.Now;
            _dbSet.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
