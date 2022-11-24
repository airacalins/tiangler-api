using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Tiangler.Core.Contexts;
using Tiangler.Core.ResultModels;

namespace Tiangler.Core.Repositories.BaseRepositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(filter: filter, orderBy: orderBy, skip: skip, take: take, include: include).ToListAsync();
        }

        public virtual async Task<List<TResult>> GetSelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(filter: filter, orderBy: orderBy, skip: skip, take: take, include: include).Select(selector).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAsyncNoTracking(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(filter: filter, orderBy: orderBy, skip: skip, take: take, include: include).AsNoTracking().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(orderBy: orderBy, skip: skip, take: take, include: include).ToListAsync();
        }

        public virtual async Task<List<TResult>> GetAllSelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(orderBy: orderBy, skip: skip, take: take, include: include).Select(selector).ToListAsync();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(filter: filter, orderBy: orderBy, include: include).FirstOrDefaultAsync();
        }

        public virtual async Task<TResult> FirstOrDefaultSelectAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            return await GetQuery(filter: filter, orderBy: orderBy, include: include).Select(selector).FirstOrDefaultAsync();
        }

        public virtual async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await GetQuery().CountAsync();
            else
                return await GetQuery().CountAsync(filter);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            return await GetQuery().AnyAsync(filter);
        }

        public virtual async Task<TEntity> FindAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
                query = include(query);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return query;
        }

        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
        }

        public virtual void AddRange(IList<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _dbSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IList<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _dbSet.RemoveRange(entities);
        }

        public async Task<PagedResult<TEntity>> GetPaged(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1, int pageSize = 10,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var result = new PagedResult<TEntity>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            var skip = (page - 1) * pageSize;

            var count = await CountAsync(filter);
            var getItems = await GetAsync(filter, orderBy, skip, pageSize, include);

            result.RowCount = count;

            var pageCount = result.RowCount == 0 ? 0 : (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Data = getItems;

            return result;
        }

        public async Task<PagedResult<TResult>> GetPagedSelect<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1, int pageSize = 10,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null) where TResult : class
        {
            var result = new PagedResult<TResult>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            var skip = (page - 1) * pageSize;

            var count = await CountAsync(filter);
            var getItems = await GetSelectAsync(selector, filter, orderBy, skip, pageSize, include);

            result.RowCount = count;

            var pageCount = result.RowCount == 0 ? 0 : (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            result.Data = getItems;

            return result;
        }

        public async Task<int> GetMaxAsync(Expression<Func<TEntity, int>> maxProperty, Expression<Func<TEntity, bool>> filter = null)
        {
            return await GetQuery(filter: filter).Select(maxProperty).OrderByDescending(x => x).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetSecuredAsync(string userId,
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var predicate = await GeneratePredicate(userId, filter);
            var result = await GetQuery(predicate, orderBy, null, null, include).ToListAsync();
            return result;
        }

        public async Task<TEntity> FirstOrDefaultSecuredAsync(string userId,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var predicate = await GeneratePredicate(userId, filter);
            var result = await GetQuery(predicate, orderBy, null, null, include).FirstOrDefaultAsync();
            return result;
        }

        public async Task<PagedResult<TEntity>> GetPagedSecured(string userId,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1, int pageSize = 10,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var predicate = await GeneratePredicate(userId, filter);
            var result = await GetPaged(predicate, orderBy, page, pageSize, include);
            return result;
        }

        public virtual async Task<Expression<Func<TEntity, bool>>> GeneratePredicate(string userId, Expression<Func<TEntity, bool>> filter)
        {
            var predicate = PredicateBuilder.New(filter);
            return predicate;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
