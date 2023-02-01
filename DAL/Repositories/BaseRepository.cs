
using DAL.Context;
using DAL.Entities.Base;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;

namespace DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual void Save(TEntity model)
        {
            if (model.Id != null)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
        }

        public virtual void BulkSave(IList<TEntity> model)
        {
            _dbSet.AddRange(model);
        }

        public virtual void RemoveAll()
        {
            _dbSet.RemoveRange(_dbSet);
        }

        public virtual void Remove(TEntity model)
        {
            _context.Remove(model);
        }

        public virtual void Remove(object id)
        {
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _context.Model.FindEntityType(typeInfo)?.FindPrimaryKey()?.Properties.FirstOrDefault();
            if (key is null)
            {
                return;
            }

            var property = typeInfo.GetProperty(key.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _context.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Remove(entity);
                }
            }
        }

        public TEntity? GetFirstOrDefault(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return orderBy is not null
                ? orderBy(query).FirstOrDefault()
                : query.FirstOrDefault();
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return orderBy is not null
                ? await orderBy(query).FirstOrDefaultAsync()
                : await query.FirstOrDefaultAsync();
        }

        public TResult? GetFirstOrDefault<TResult>(
           Expression<Func<TEntity, TResult>> selector,
           Expression<Func<TEntity, bool>>? predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool disableTracking = true,
           bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return orderBy is not null
                ? orderBy(query).Select(selector).FirstOrDefault()
                : query.Select(selector).FirstOrDefault();
        }

        public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true, bool ignoreQueryFilters = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include is not null)
            {
                query = include(query);
            }

            if (predicate is not null)
            {
                query = query.Where(predicate);
            }

            if (ignoreQueryFilters)
            {
                query = query.IgnoreQueryFilters();
            }

            return orderBy is not null
                ? await orderBy(query).Select(selector).FirstOrDefaultAsync()
                : await query.Select(selector).FirstOrDefaultAsync();
        }
    }
}
