using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        TEntity? GetFirstOrDefault(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);
        TResult? GetFirstOrDefault<TResult>(
           Expression<Func<TEntity, TResult>> selector,
           Expression<Func<TEntity, bool>>? predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool disableTracking = true,
           bool ignoreQueryFilters = false);
        Task<TResult?> GetFirstOrDefaultAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool disableTracking = true,
            bool ignoreQueryFilters = false);

        Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>>? predicate = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool disableTracking = true,
           bool ignoreQueryFilters = false);

        void Save(TEntity model);
        void BulkSave(IList<TEntity> model);
        void RemoveAll();
        void Remove(TEntity model);
        void Remove(object id);
    }
}
